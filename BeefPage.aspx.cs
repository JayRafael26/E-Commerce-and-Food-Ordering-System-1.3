using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        
        protected void CalculatePlus(object sender, EventArgs e)
        {
            Button btn = (sender) as Button;
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            int qty = Convert.ToInt16((item.FindControl("txtQuantity") as TextBox).Text);
            qty++;
            (item.FindControl("txtQuantity") as TextBox).Text = qty.ToString();
        }

        protected void CalculateMinus(object sender, EventArgs e)
        {
            Button btn = (sender) as Button;
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            int qty = Convert.ToInt16((item.FindControl("txtQuantity") as TextBox).Text);
            qty--;
            (item.FindControl("txtQuantity") as TextBox).Text = qty.ToString();
        }

        private static void UpdateCartItemQuantity(int ProductID, int totalQuantity)
        {
            DBConnection DB = new DBConnection();
            float totalPrice = computePricePerProduct(ProductID, totalQuantity);
            try
            {
                int CartItemID = Int32.Parse(System.Web.HttpContext.Current.Session["CartItemID"].ToString());
                Console.Write(CartItemID);
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE testCartItems SET CartQuantity = @cq, CartPrice = @cp Where CartItemID = @CIID", DB.con);
                cmd.Parameters.AddWithValue("@cq", totalQuantity);
                cmd.Parameters.AddWithValue("@cp", totalPrice);
                cmd.Parameters.AddWithValue("@CIID", CartItemID);
                cmd.ExecuteNonQuery();
                DB.con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private static float computePricePerProduct(int ProductID, int quantity)
        {
            DBConnection DB = new DBConnection();
            int cartQuantity = quantity;
            float totalPrice = 0;
            try
            {
                if (DB.con.State == System.Data.ConnectionState.Closed)
                {
                    DB.con.Open();
                }
                SqlCommand cmd = new SqlCommand("select ProductPrice from products_tbl where ProductID= @PID", DB.con);
                cmd.Parameters.AddWithValue("@PID", ProductID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        int ProductPrice = Int32.Parse(dr.GetValue(0).ToString());
                        totalPrice = cartQuantity * ProductPrice;
                        return totalPrice;
                    }
                }
                return totalPrice;
                //Response.Write("Add to Cart Success!");
            }
            catch (Exception ea)
            {

                Console.Write(ea.Message);
                return totalPrice;
            }

        }

        private static void InsertIntoCart(int ProductID, int quantity, int CartID)
        {
            DBConnection DB = new DBConnection();
            float totalPrice = computePricePerProduct(ProductID, quantity);
            try
            {
                if (DB.con.State == System.Data.ConnectionState.Closed)
                {
                    DB.con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO testCartItems(CartProductID, CartQuantity, CartPrice, CartID) values (@cartProdID, @cartProdQuantity, @cartPrice, @cartID)", DB.con);
                cmd.Parameters.AddWithValue("@cartProdID", ProductID);
                cmd.Parameters.AddWithValue("@cartProdQuantity", quantity);
                cmd.Parameters.AddWithValue("@cartPrice", totalPrice);
                cmd.Parameters.AddWithValue("@cartID", CartID);

                cmd.ExecuteNonQuery();
                //Response.Write("Add to Cart Success!");
            }
            catch (Exception ea)
            {
                Console.Write(ea.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            DBConnection DB = new DBConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT *, cast(ProductPrice as decimal(10,2)) AS ProdPrice FROM products_tbl where CategoryID=2 AND ProductQuantity > 0", DB.con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    repeater.DataSource = dt;
                    repeater.DataBind();
                }
            }
        }


        private string CheckCart(int CartID, int Pid)
        {
            string check = "";
            DBConnection DB = new DBConnection();
            DB.con.Open();
            SqlCommand cmd = new SqlCommand("select * from testCartItems where CartID= @CID AND CartProductID=@CPID", DB.con);
            cmd.Parameters.AddWithValue("@CID", CartID);
            cmd.Parameters.AddWithValue("@CPID", Pid);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    check = "True";
                    System.Web.HttpContext.Current.Session["CartItemID"] = dr.GetValue(0);
                    System.Web.HttpContext.Current.Session["CurrentItemQuantity"] = dr.GetValue(2);
                    return check;
                }
            }
            return check;
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString().Equals("user"))
                {

                    try
                    {
                        //Reference the Repeater Item using Button.
                        RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

                        //Reference the Label and TextBox.
                        //DateTime localDate = DateTime.Now;
                        int Pid = Int32.Parse((item.FindControl("PID") as Label).Text);
                        int userQuantity = Int32.Parse((item.FindControl("txtQuantity") as TextBox).Text);
                        int productQuantity = Int32.Parse((item.FindControl("ProdQuantity") as Label).Text);
                        if (userQuantity >= 1)
                        {
                            string message = "";
                            int CartID = Int32.Parse(System.Web.HttpContext.Current.Session["CartID"].ToString());
                            if (userQuantity <= productQuantity)
                            {
                                string checkCart = CheckCart(CartID, Pid);
                                if (checkCart.Equals("True"))
                                {
                                    int currentQuantity = Int32.Parse(System.Web.HttpContext.Current.Session["CurrentItemQuantity"].ToString());
                                    int totalQuantity = currentQuantity + userQuantity;
                                    string[] itemDetails = new string[3];
                                    itemDetails = getProductDetails(Pid);
                                    if (totalQuantity <= productQuantity)
                                    {
                                        UpdateCartItemQuantity(Pid, totalQuantity);

                                        string itemID = itemDetails[0];
                                        string itemName = itemDetails[1];
                                        firstPhrase.Text = "You have successfully";
                                        condition.Text = "updated";
                                        ProdID.Text = itemID;
                                        lastPhrase.Text = "in your Cart.";
                                        addedItem.Text = itemName;
                                        ProceedToLogin.Visible = false;
                                        AddMoreItemsButton.Visible = true;
                                        ProceedToCartButton.Visible = true;
                                        closeButton.Visible = false;
                                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddedToCartModal", "$('#AddedToCartModal').modal();", true);
                                        upModal.Update();
                                    }

                                    else
                                    {
                                        int productstock = Convert.ToInt32(itemDetails[2]);
                                        string itemName = itemDetails[1];
                                        int availableforcart = totalQuantity - productstock;
                                        firstPhrase.Text = "This Item is already in your Cart. You can only add: <br/>";
                                        condition.Text = availableforcart.ToString();
                                        condition.ForeColor = Color.Green;
                                        ProdID.Text = "";
                                        addedItem.Text = "more of " + itemName;
                                        lastPhrase.Text = "";
                                        ProceedToLogin.Visible = false;
                                        AddMoreItemsButton.Visible = false;
                                        ProceedToCartButton.Visible = false;
                                        closeButton.Visible = true;
                                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddedToCartModal", "$('#AddedToCartModal').modal();", true);
                                        upModal.Update();
                                    }
                                }
                                else
                                {
                                    InsertIntoCart(Pid, userQuantity, CartID);

                                    string[] itemDetails = new string[2];
                                    itemDetails = getProductDetails(Pid);
                                    string itemID = itemDetails[0];
                                    string itemName = itemDetails[1];
                                    firstPhrase.Text = "You have successfully";
                                    condition.Text = "inserted";
                                    ProdID.Text = itemID;
                                    lastPhrase.Text = "to your Cart.";
                                    addedItem.Text = itemName;
                                    ProceedToLogin.Visible = false;
                                    AddMoreItemsButton.Visible = true;
                                    ProceedToCartButton.Visible = true;
                                    closeButton.Visible = false;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddedToCartModal", "$('#AddedToCartModal').modal();", true);
                                    upModal.Update();

                                }
                            }

                            else
                            {
                                firstPhrase.Text = "Quantity selected is greater than the available stock. Please reduce your Quantity.";
                                condition.Text = "";
                                ProdID.Text = "";
                                addedItem.Text = "";
                                lastPhrase.Text = "";
                                ProceedToLogin.Visible = false;
                                AddMoreItemsButton.Visible = false;
                                ProceedToCartButton.Visible = false;
                                closeButton.Visible = true;
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddedToCartModal", "$('#AddedToCartModal').modal();", true);
                                upModal.Update();
                            }
                        }
                        else
                        {
                            firstPhrase.Text = "Minimum Quantity is 1";
                            condition.Text = "";
                            ProdID.Text = "";
                            addedItem.Text = "";
                            lastPhrase.Text = "";
                            ProceedToLogin.Visible = false;
                            AddMoreItemsButton.Visible = false;
                            ProceedToCartButton.Visible = false;
                            closeButton.Visible = true;
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddedToCartModal", "$('#AddedToCartModal').modal();", true);
                            upModal.Update();
                        }
                    }
                    catch (Exception ea)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ea.Message + "');", true);
                    }
                }
                else if (Session["role"].ToString().Equals(""))
                {
                    firstPhrase.Text = "Please log-in first to Add to your Cart";
                    condition.Text = "";
                    ProdID.Text = "";
                    addedItem.Text = "";
                    lastPhrase.Text = "";
                    ProceedToLogin.Visible = true;
                    AddMoreItemsButton.Visible = false;
                    ProceedToCartButton.Visible = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddedToCartModal", "$('#AddedToCartModal').modal();", true);
                    upModal.Update();
                }
            }
            else
            {
                firstPhrase.Text = "Please log-in first to Add to your Cart";
                condition.Text = "";
                ProdID.Text = "";
                addedItem.Text = "";
                lastPhrase.Text = "";
                ProceedToLogin.Visible = true;
                AddMoreItemsButton.Visible = false;
                ProceedToCartButton.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddedToCartModal", "$('#AddedToCartModal').modal();", true);
                upModal.Update();
            }

        }
        protected static string[] getProductDetails(int Pid)
        {
            //string username = System.Web.HttpContext.Current.Session["username"].ToString();
            int CartID = Int32.Parse(System.Web.HttpContext.Current.Session["CartID"].ToString());
            string[] prodDetails = new string[3];
            DBConnection DB = new DBConnection();
            DB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * from products_tbl WHERE ProductID = @Pid", DB.con);
                cmd.Parameters.AddWithValue("@Pid", Pid);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string prodID = dr.GetValue(0).ToString();
                        string prodName = dr.GetValue(2).ToString();
                        string prodStock = dr.GetValue(3).ToString();
                        prodDetails[0] = prodID;
                        prodDetails[1] = prodName;
                        prodDetails[2] = prodStock;
                        return prodDetails;
                    }
                }
                DB.con.Close();
                return prodDetails;
            }
            catch
            {
                DB.con.Close();
                return prodDetails;
            }
        }

        protected void ProceedToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }

        protected void ProceedToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}