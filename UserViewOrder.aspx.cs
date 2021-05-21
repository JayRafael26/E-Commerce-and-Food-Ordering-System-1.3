using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype.ASPX
{
    public partial class UserViewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int orderid = Convert.ToInt32(Session["OrderToView"]);
            decimal ordertotal = getTotalPrice(orderid);
            if (!Page.IsPostBack)
            {
                try
                {
                    DBConnection DB = new DBConnection();
                    DB.con.Open();
                    SqlCommand cmd = new SqlCommand("select *, cast(OrderItemPrice as decimal(10,2)) AS ItemPrice from testOrderedItems_tbl " +
                        "JOIN products_tbl ON testOrderedItems_tbl.OrderProductID = products_tbl.ProductID WHERE OrderID = @orderid", DB.con);
                    cmd.Parameters.AddWithValue("@orderid", orderid);
                    OrderID.Text = orderid.ToString();
                    OrderTotal.Text = ordertotal.ToString();
                    ViewOrderedItems.DataSource = cmd.ExecuteReader();
                    ViewOrderedItems.DataBind();
                    DB.con.Close();

                    string validCancelOrderdate = getDates(orderid);
                    string orderStatus = getStatus(orderid);
                    DateTime now = DateTime.Now;
                    DateTime validcanceldate = DateTime.Parse(validCancelOrderdate);
                    if(now > validcanceldate || orderStatus == "Canceled" || orderStatus == "Completed")
                    {
                        CancelOrderButton.Visible = false;
                        CancelOrderModalTrigger.Visible = false;
                    }
                    else
                    {
                        CancelOrderButton.Visible = true;
                        CancelOrderModalTrigger.Visible = true;
                    }

                    
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
        }
        protected decimal getTotalPrice(int orderid)
        {
            DBConnection DB = new DBConnection();
            DB.con.Open();
            SqlCommand cmd = new SqlCommand("select cast(OrderTotalprice as decimal(10, 2)) AS OrderTotal from testOrders2_tbl WHERE OrderID = @orderid", DB.con);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            decimal totalprice = Convert.ToDecimal(cmd.ExecuteScalar());
            DB.con.Close();
            return totalprice;
        }

        protected string getDates(int orderid)
        {
            DBConnection DB = new DBConnection();
            DB.con.Open();
            SqlCommand cmd = new SqlCommand("select ValidCancelDate from testOrders2_tbl WHERE OrderID = @orderid", DB.con);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            string date = Convert.ToString(cmd.ExecuteScalar());

            DB.con.Close();
            return date;
        }

        protected string getStatus(int orderid)
        {
            DBConnection DB = new DBConnection();
            DB.con.Open();
            SqlCommand cmd = new SqlCommand("select OrderStatus from testOrders2_tbl WHERE OrderID = @orderid", DB.con);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            string status = Convert.ToString(cmd.ExecuteScalar());

            DB.con.Close();
            return status;
        }

        protected void modalPromptButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "CancelOrderModal", "$('#CancelOrderModal').modal();", true);
            upModal.Update();
        }

            protected void CancelOrderButton_Click(object sender, EventArgs e)
        {
            int orderid = Convert.ToInt32(Session["OrderToView"]);
            ItemsReturnQuantity(orderid);
            UpdateOrderStatus(orderid);
            Response.Redirect("UserOrders.aspx");
        }

        protected void ItemsReturnQuantity(int orderID)
        {
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

        protected static int countAllDistinctOrderedItems(int orderID)
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

        protected void UpdateOrderStatus(int orderid)
        {
            DBConnection DB = new DBConnection();
            SqlCommand cmd = new SqlCommand("UPDATE testOrders2_tbl SET OrderStatus = @status Where OrderID = @oid", DB.con);
            cmd.Parameters.AddWithValue("@oid", orderid);
            cmd.Parameters.AddWithValue("@status", "Canceled");
            DB.con.Open();
            cmd.ExecuteNonQuery();
            DB.con.Close();
        }
    }
}