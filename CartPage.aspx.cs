using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string username = Session["username"].ToString();
                    DBConnection DB = new DBConnection();
                    DB.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT testCart2.CartID, testCart2.CartCustomerID, testCartItems.CartItemID, testCartItems.CartProductID,products_tbl.ProductName, products_tbl.ProductQuantity, products_tbl.ImagePath, testCartItems.CartQuantity, testCartItems.CartPrice " +
                                                    "FROM testCart2 JOIN testCartItems ON testCart2.CartID = testCartItems.CartID JOIN products_tbl ON testCartItems.CartProductID = products_tbl.ProductID " +
                                                    "WHERE CartCustomerID = @username AND testCartItems.CartQuantity <= products_tbl.ProductQuantity", DB.con);
                    cmd.Parameters.AddWithValue("@username", username);
                    PrintCartItems.DataSource = cmd.ExecuteReader();
                    PrintCartItems.DataBind();

                    float totalCartPrice = TotalCartPrice(username);
                    SubTotal.Text = totalCartPrice.ToString();
                    TotalAmount.Text = totalCartPrice.ToString();
                    Session["TotalCartPrice"] = totalCartPrice;
                    DB.con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
        }

        private static float TotalCartPrice(string username)
        {
            float totalCartPrice = 0;
            DBConnection DB = new DBConnection();
            DB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(testCartItems.CartPrice) AS totalCartPrice " +
                    "FROM testCart2 JOIN testCartItems ON testCart2.CartID = testCartItems.CartID JOIN products_tbl ON testCartItems.CartProductID = products_tbl.ProductID " +
                    "WHERE CartCustomerID = @username AND testCartItems.CartQuantity <= products_tbl.ProductQuantity", DB.con);

                cmd.Parameters.AddWithValue("@username", username);
                totalCartPrice = (float)Convert.ToDecimal(cmd.ExecuteScalar());
                DB.con.Close();
                return totalCartPrice;
            }
            catch
            {
                DB.con.Close();
                return totalCartPrice;
            }
        }

        protected void modalPromptButton_Click(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
                int Pid = Int32.Parse((item.FindControl("RemoveThis") as Label).Text);
                string[] itemDetails = new string[2];
                itemDetails = getProductDetails(Pid);
                string itemID = itemDetails[0];
                string itemName = itemDetails[1];
                ProdID.Text = itemID;
                itemNameRemove.Text = itemName;
                ModalTitle.Text = "Confirm Removal";
                ModalFunction.Text = "Are you sure you want to remove";
                modalButton.Visible = true;
                closeModalRemoveButton.Visible = true;
                ProceedToProductsPage.Visible = false;
                OrderSuccessButton.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RemoveModal", "$('#RemoveModal').modal();", true);
                upModal.Update();
            }
            catch
            {

            }
            
        }

        protected static string[] getProductDetails(int Pid)
        {
            string username = System.Web.HttpContext.Current.Session["username"].ToString();
            int CartID = Int32.Parse(System.Web.HttpContext.Current.Session["CartID"].ToString());
            string[] prodDetails = new string[2];
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
                        prodDetails[0] = prodID;
                        prodDetails[1] = prodName;
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

        protected void RemoveItemFromCart(object sender, EventArgs e)
        {
            int CartID = Int32.Parse(System.Web.HttpContext.Current.Session["CartID"].ToString());
            int CartProdID = Int32.Parse(ProdID.Text);
            DBConnection DB = new DBConnection();
            Console.Write(CartID + " " + CartProdID);

            try
            {
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM testCartItems WHERE CartID = @CartID AND CartProductID = @CartProdID", DB.con);
                cmd.Parameters.AddWithValue("@CartID", CartID);
                cmd.Parameters.AddWithValue("@CartProdID", CartProdID);
                cmd.ExecuteNonQuery();
                DB.con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Response.Redirect("CartPage.aspx");

        }

        protected void UpdateQuantity(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as TextBox).NamingContainer as RepeaterItem;
                int quantity = Int32.Parse((item.FindControl("QuantityBox") as TextBox).Text);
                int maxqty = Int32.Parse((item.FindControl("MaximumQuantity") as HiddenField).Value);
                if(quantity > 0)
                {
                    if(quantity <= maxqty)
                    {
                        int PID = Int32.Parse((item.FindControl("PID") as HiddenField).Value);
                        DBConnection DB = new DBConnection();
                        float totalPrice = computePricePerProduct(PID, quantity);
                        getID(PID);
                        try
                        {
                            int CartItemID = Int32.Parse(System.Web.HttpContext.Current.Session["CartItemID"].ToString());
                            DB.con.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE testCartItems SET CartQuantity = @cq, CartPrice = @cp Where CartItemID = @CIID", DB.con);
                            cmd.Parameters.AddWithValue("@cq", quantity);
                            cmd.Parameters.AddWithValue("@cp", totalPrice);
                            cmd.Parameters.AddWithValue("@CIID", CartItemID);
                            cmd.ExecuteNonQuery();
                            DB.con.Close();
                            Response.Redirect("CartPage.aspx");
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                    }
                    else
                    {
                        ModalTitle.Text = "Invalid Quantity";
                        ModalFunction.Text = "Maximum Quantity of this Product is: " + maxqty.ToString();
                        itemNameRemove.Text = "";
                        ProceedToProductsPage.Visible = false;
                        modalButton.Visible = false;
                        closeModalRemoveButton.Visible = false;
                        OrderSuccessButton.Visible = true;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RemoveModal", "$('#RemoveModal').modal();", true);
                        upModal.Update();
                    }
                }
                else
                {
                    ModalTitle.Text = "Invalid Quantity";
                    ModalFunction.Text = "Please input a quantity more than 0";
                    itemNameRemove.Text = "";
                    ProceedToProductsPage.Visible = false;
                    modalButton.Visible = false;
                    closeModalRemoveButton.Visible = false;
                    OrderSuccessButton.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RemoveModal", "$('#RemoveModal').modal();", true);
                    upModal.Update();
                }
            }
            catch(Exception ex)
            {
                ModalTitle.Text = "Invalid Quantity";
                ModalFunction.Text = "Only numbers are allowed in the Quantity Box";
                itemNameRemove.Text = "";
                ProceedToProductsPage.Visible = false;
                modalButton.Visible = false;
                closeModalRemoveButton.Visible = false;
                OrderSuccessButton.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RemoveModal", "$('#RemoveModal').modal();", true);
                upModal.Update();
            }
        }

        private void getID(int Pid){
            int CartID = Convert.ToInt32(Session["CartID"].ToString());
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
                    System.Web.HttpContext.Current.Session["CartItemID"] = dr.GetValue(0);
                }
            }
        }

        private static float computePricePerProduct(int PID, int quantity)
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
                cmd.Parameters.AddWithValue("@PID", PID);
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

        protected void ConfirmOrder(object sender, EventArgs e)
        {
            DBConnection DB = new DBConnection();
            if((int)Session["cartCounter"] > 0)
            {
                try
                {
                    DateTime localDate = DateTime.Now;
                    int CartID = Convert.ToInt32(Session["CartID"].ToString());
                    string dateTime = localDate.ToString("g");
                    string username = Session["username"].ToString();
                    decimal totalAmount = Convert.ToDecimal(Session["TotalCartPrice"].ToString());
                    string transpo = "";
                    if (RadioButton1.Checked)
                    {
                        transpo = RadioButton1.Text;
                    }
                    else
                    {
                        transpo = RadioButton2.Text;
                    }
                    DateTime validCancel = localDate.AddHours(24);
                    string validCancelDate = validCancel.ToString("g");
                    int OrderID = SetOrderDetails(username, dateTime, totalAmount, transpo, validCancelDate); //generate the order id
                    Session["OrderID"] = OrderID;
                    int counter = countOrderedItems(CartID); //to count how many rows are in the cart of the user
                    int[] checklang = new int[counter];
                    processOrder(OrderID, CartID, counter);

                    
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                ModalTitle.Text = "Order Failed";
                ModalFunction.Text = "Please Add Items to the Cart";
                modalButton.Visible = false;
                closeModalRemoveButton.Visible = false;
                OrderSuccessButton.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RemoveModal", "$('#RemoveModal').modal();", true);
                upModal.Update();
            }
            
        }


        private static int SetOrderDetails(string username, string dateTime, decimal totalAmount, string transpo, string validCancelDate)
        {
            int orderID = 0;
            string custID = username;
            string orderDate = dateTime;
            string orderStatus = "Pending";
            DBConnection DB = new DBConnection();
            int cartCounter = Convert.ToInt32(System.Web.HttpContext.Current.Session["cartCounter"]);
                try
                {

                    DB.con.Open();
                    SqlCommand insert = new SqlCommand("INSERT INTO testOrders2_tbl(OrderDate, OrderTotalPrice, PaymentMethod, OrderStatus, CustomerID, ValidCancelDate) output INSERTED.OrderID values (@orderdate, @ordertotalprice, @payment, @status, @username, @cancel)", DB.con);
                    insert.Parameters.AddWithValue("@orderdate", orderDate);
                    insert.Parameters.AddWithValue("@ordertotalprice", totalAmount);
                    insert.Parameters.AddWithValue("@payment", transpo);
                    insert.Parameters.AddWithValue("@status", orderStatus);
                    insert.Parameters.AddWithValue("@username", custID);
                    insert.Parameters.AddWithValue("@cancel", validCancelDate);

                orderID = Convert.ToInt32(insert.ExecuteScalar());
                    System.Web.HttpContext.Current.Session["OrderID"] = orderID;
                    DB.con.Close();
                    
                    return orderID;
                }
                catch (Exception ea)
                {

                    Console.Write(ea.Message);
                }
                return orderID;
        }
       
        private static int countOrderedItems(int CartID)
        {
            int counter = 0;
            DBConnection DB = new DBConnection();
            try
            {
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(CartItemID) FROM testCartItems " +
                    "Join products_tbl ON testCartItems.CartProductID = products_tbl.ProductID " +
                    "WHERE CartID = @CID AND testCartItems.CartQuantity <= products_tbl.ProductQuantity", DB.con);
                cmd.Parameters.AddWithValue("@CID", CartID);
                counter = Convert.ToInt32(cmd.ExecuteScalar());
                return counter;
            }
            catch
            {
                return counter;
            }
        }

        private void processOrder(int orderID, int CartID, int counter) //has 4 functions: get details from the cart, insert those details to the orders, delete the cart items and decrease the stock quantity
        {
            DBConnection DB = new DBConnection();
            int[] CartItemIDs = new int[counter];
            int[] CartProductID = new int[counter];
            int[] CartQuantity = new int[counter];
            int[] CartPrice = new int[counter];
            try
            {
                if (DB.con.State == System.Data.ConnectionState.Closed)
                {
                    DB.con.Open();
                }
                //get all the details from the cart items
                SqlCommand cmd = new SqlCommand("SELECT * FROM testCartItems " +
                    "Join products_tbl ON testCartItems.CartProductID = products_tbl.ProductID " +
                    "WHERE CartID = @CID AND testCartItems.CartQuantity <= products_tbl.ProductQuantity", DB.con);
                cmd.Parameters.AddWithValue("@CID", CartID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        CartItemIDs[i] = Convert.ToInt32(dr.GetValue(0).ToString());
                        CartProductID[i] = Convert.ToInt32(dr.GetValue(1).ToString());
                        CartQuantity[i] = Convert.ToInt32(dr.GetValue(2).ToString());
                        CartPrice[i] = Convert.ToInt32(dr.GetValue(3).ToString());
                        i++;
                    }
                    DB.con.Close();
                }
                //Insert the Cart Item details to confirm order
                for(int i = 0; i<counter; i++)
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO testOrderedItems_tbl(OrderProductID, OrderItemQuantity, OrderItemPrice, OrderID) values (@orderedPID, @orderedItemQuantity, @orderedItemPrice, @orderedid)", DB.con);
                    DB.con.Open();
                    insert.Parameters.AddWithValue("@orderedPID", CartProductID[i]);
                    insert.Parameters.AddWithValue("@orderedItemQuantity", CartQuantity[i]);
                    insert.Parameters.AddWithValue("@orderedItemPrice", CartPrice[i]);
                    insert.Parameters.AddWithValue("@orderedid", orderID);
                    insert.ExecuteNonQuery();
                    DB.con.Close();
                }

                //delete all items in cart after pressing confirm order
                DB.con.Open();
                SqlCommand delete = new SqlCommand("DELETE FROM testCartItems WHERE CartID = @CartID", DB.con);
                delete.Parameters.AddWithValue("@CartID", CartID);
                delete.ExecuteNonQuery();
                DB.con.Close();

                ItemsDecreaseQuantity();
                ModalTitle.Text = "Order Success";
                ModalFunction.Text = "You have successfully placed your order. Thank you!";
                itemNameRemove.Text = "";
                modalButton.Visible = false;
                closeModalRemoveButton.Visible = false;
                OrderSuccessButton.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RemoveModal", "$('#RemoveModal').modal();", true);
                upModal.Update();

                Session["OrderID"] = "";
            }
            catch (Exception ea)
            {
                Response.Write(ea.Message);
            }
        }

        private void ItemsDecreaseQuantity()
        {
            int orderID = Convert.ToInt32(System.Web.HttpContext.Current.Session["OrderID"]);
            int count = countAllDistinctOrderedItems(orderID);
            int[] OrderPID = new int[count];
            int[] OrderItemQuantity = new int[count];
            int[] currentStock = new int[count];
            int[] finalStock = new int[count];
            DBConnection DB = new DBConnection();
            DB.con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT OrderProductID FROM testOrderedItems_tbl WHERE OrderID = @OID", DB.con); //get all distinct product IDs
            cmd.Parameters.AddWithValue("@OID", orderID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    OrderPID[i] = Convert.ToInt32(dr.GetValue(0).ToString());
                    i++;
                }
            }
            DB.con.Close();


            for (int i = 0; i < count; i++)
            {
                DB.con.Open();
                int temp = 0;
                SqlCommand cmd1 = new SqlCommand("SELECT OrderItemQuantity FROM testOrderedItems_tbl WHERE OrderProductID = @OrderPID AND OrderID = @OID", DB.con); //add all the quantities per Product ID
                cmd1.Parameters.AddWithValue("@OrderPID", OrderPID[i]);
                cmd1.Parameters.AddWithValue("@OID", orderID);
                temp = Convert.ToInt32(cmd1.ExecuteScalar());
                OrderItemQuantity[i] = temp;
                DB.con.Close();
            }

            for (int i = 0; i < count; i++)
            {
                //now get the current stock per product
                DB.con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT ProductQuantity FROM products_tbl WHERE ProductID = @OrderPID", DB.con); //get all distinct product IDs
                cmd2.Parameters.AddWithValue("@OrderPID", OrderPID[i]);
                currentStock[i] = Convert.ToInt32(cmd2.ExecuteScalar());
                DB.con.Close();
            }

            for (int i = 0; i < count; i++)
            {
                finalStock[i] = currentStock[i] - OrderItemQuantity[i];
            }

            for(int i = 0; i < count; i++)
            {
                DB.con.Open();
                SqlCommand update = new SqlCommand("UPDATE products_tbl SET ProductQuantity = @pq Where ProductID = @pid", DB.con);
                update.Parameters.AddWithValue("@pq", finalStock[i]);
                update.Parameters.AddWithValue("@pid", OrderPID[i]);
                update.ExecuteNonQuery();
                DB.con.Close();
            }
        }
            
        private static int countAllDistinctOrderedItems(int orderID)
        {
            int counter = 0;
            DBConnection DB = new DBConnection();
            try
            {
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT OrderProductID) FROM testOrderedItems_tbl WHERE OrderID = @OID", DB.con);
                cmd.Parameters.AddWithValue("@OID", orderID);
                counter = Convert.ToInt32(cmd.ExecuteScalar());
                DB.con.Close();
                return counter;
            }
            catch
            {
                DB.con.Close();
                return counter;
            }
        }

        protected void RefreshPage(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }

        protected void ProceedToProductsPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChickenPage.aspx");
        }


    }
}