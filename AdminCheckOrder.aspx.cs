using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype.ASPX
{
    public partial class AdminCheckOrder : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sOid = Session["searchOid"].ToString();
            if (!IsPostBack)
            {
                // Response.Write(sOid);
                try
                {
                    string[] details = new string[8];
                    DBConnection DB = new DBConnection();
                    if (DB.con.State == System.Data.ConnectionState.Closed)
                    {
                        DB.con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT testOrders2_tbl.OrderID, testOrders2_tbl.OrderDate, testOrders2_tbl.PaymentMethod, customer_tbl.CustomerID, customer_tbl.FirstName, customer_tbl.LastName," +
                        "customer_tbl.Street,customer_tbl.City, customer_tbl.Phone, testOrders2_tbl.OrderStatus FROM testOrders2_tbl JOIN customer_tbl ON testOrders2_tbl.CustomerID = customer_tbl.CustomerID" +
                        " WHERE OrderID = @sid", DB.con);
                    cmd.Parameters.AddWithValue("@sid", sOid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            details[0] = dr.GetValue(0).ToString();
                            details[1] = dr.GetValue(1).ToString();
                            details[2] = dr.GetValue(2).ToString();
                            details[3] = dr.GetValue(4).ToString() + " " + dr.GetValue(5).ToString();
                            details[4] = dr.GetValue(6).ToString();
                            details[5] = dr.GetValue(7).ToString();
                            details[6] = dr.GetValue(8).ToString();
                            details[7] = dr.GetValue(9).ToString();
                        }
                        DB.con.Close();
                    }


                    OrderID.Text = details[0];
                    OrderDate.Text = details[1];
                    PaymenMethod.Text = details[2];
                    FullName.Text = details[3];
                    Street.Text = details[4];
                    City.Text = details[5];
                    Contact.Text = details[6];
                    OrderStatus.SelectedValue = details[7];

                    if (DB.con.State == System.Data.ConnectionState.Closed)
                    {
                        DB.con.Open();
                    }
                    SqlCommand cmd1 = new SqlCommand("SELECT testOrders2_tbl.OrderID, testOrders2_tbl.CustomerID, testOrderedItems_tbl.OrderItemID, testOrderedItems_tbl.OrderProductID, products_tbl.ProductName, products_tbl.ProductQuantity, testOrderedItems_tbl.OrderItemQuantity, testOrderedItems_tbl.OrderItemPrice FROM testOrders2_tbl JOIN testOrderedItems_tbl ON testOrders2_tbl.OrderID = testOrderedItems_tbl.OrderID JOIN products_tbl ON testOrderedItems_tbl.OrderProductID = products_tbl.ProductID WHERE testOrders2_tbl.OrderID = @sid", DB.con);
                    cmd1.Parameters.AddWithValue("@sid", sOid);
                    PrintOrderItems.DataSource = cmd1.ExecuteReader();
                    PrintOrderItems.DataBind();

                    int TotalPrice = 0;
                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM testOrders2_tbl WHERE OrderID = @sid", DB.con);
                    cmd2.Parameters.AddWithValue("@sid", sOid);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            TotalPrice = Convert.ToInt32(dr2.GetValue(2).ToString());
                        }
                        DB.con.Close();
                    }
                    totalPrice.Text = TotalPrice.ToString();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void UpdateItem_Click(object sender, EventArgs e)
        {
            string sOid = Session["searchOid"].ToString();
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE testOrders2_tbl set OrderStatus =@orderstatus WHERE (OrderID =@sid)", con);

                cmd.Parameters.AddWithValue("@sid", sOid);
                cmd.Parameters.AddWithValue("@orderstatus", OrderStatus.SelectedValue);

                if (OrderStatus.SelectedValue == "Canceled" || OrderStatus.SelectedValue == "Returned")
                {
                    ItemsReturnQuantity();
                }

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Successfully Updated Order Status');</script>");
            }
            catch (Exception ex)
            {

            }

        }

        private void ItemsReturnQuantity()
        {
            int orderID = Convert.ToInt32(System.Web.HttpContext.Current.Session["searchOid"]);
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
                finalStock[i] = currentStock[i] + OrderItemQuantity[i];
            }

            for (int i = 0; i < count; i++)
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

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOrders.aspx");
        }
    }
}