using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype.ASPX
{
    public partial class UserOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllOrders();
                AllOrdersButton.ForeColor = Color.Gray;
                PendingButton.ForeColor = Color.Blue;
                ShippedButton.ForeColor = Color.Blue;
                CompletedButton.ForeColor = Color.Blue;
                CanceledButton.ForeColor = Color.Blue;
            }
        }

        protected void LoadAllOrders()
        {
            try
            {
                string username = Session["username"].ToString();
                DBConnection DB = new DBConnection();
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("select *, cast(OrderTotalprice as decimal(10,2)) AS OrderTotal from testOrders2_tbl WHERE CustomerID = @username", DB.con);
                cmd.Parameters.AddWithValue("@username", username);
                PrintOrderItems.DataSource = cmd.ExecuteReader();
                PrintOrderItems.DataBind();
                DB.con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void ViewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //Reference the Repeater Item using Button.
                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

                //Reference the Label and TextBox.
                //DateTime localDate = DateTime.Now;
                int OrderID = Int32.Parse((item.FindControl("OrderIDLabel") as Label).Text);
                Session["OrderToView"] = OrderID;
                Response.Redirect("UserViewOrder.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void AllOrders_Click(object sender, EventArgs e)
        {
            LoadAllOrders();
            AllOrdersButton.ForeColor = Color.Gray;
            PendingButton.ForeColor = Color.Blue;
            ShippedButton.ForeColor = Color.Blue;
            CompletedButton.ForeColor = Color.Blue;
            CanceledButton.ForeColor = Color.Blue;
        }

        protected void Pending_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string method = "Pending";
            try
            {
                DBConnection DB = new DBConnection();
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("select *, cast(OrderTotalprice as decimal(10,2)) AS OrderTotal from testOrders2_tbl WHERE CustomerID = @username AND OrderStatus = @method", DB.con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@method", method);
                PrintOrderItems.DataSource = cmd.ExecuteReader();
                PrintOrderItems.DataBind();
                DB.con.Close();
                AllOrdersButton.ForeColor = Color.Blue;
                PendingButton.ForeColor = Color.Gray;
                ShippedButton.ForeColor = Color.Blue;
                CompletedButton.ForeColor = Color.Blue;
                CanceledButton.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Shipped_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string method = "Shipped";
            try
            {
                DBConnection DB = new DBConnection();
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("select *, cast(OrderTotalprice as decimal(10,2)) AS OrderTotal from testOrders2_tbl WHERE CustomerID = @username AND OrderStatus = @method", DB.con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@method", method);
                PrintOrderItems.DataSource = cmd.ExecuteReader();
                PrintOrderItems.DataBind();
                DB.con.Close();
                AllOrdersButton.ForeColor = Color.Blue;
                PendingButton.ForeColor = Color.Blue;
                ShippedButton.ForeColor = Color.Gray;
                CompletedButton.ForeColor = Color.Blue;
                CanceledButton.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Completed_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string method = "Completed";
            try
            {
                DBConnection DB = new DBConnection();
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("select *, cast(OrderTotalprice as decimal(10,2)) AS OrderTotal from testOrders2_tbl WHERE CustomerID = @username AND OrderStatus = @method", DB.con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@method", method);
                PrintOrderItems.DataSource = cmd.ExecuteReader();
                PrintOrderItems.DataBind();
                DB.con.Close();
                AllOrdersButton.ForeColor = Color.Blue;
                PendingButton.ForeColor = Color.Blue;
                ShippedButton.ForeColor = Color.Blue;
                CompletedButton.ForeColor = Color.Gray;
                CanceledButton.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Canceled_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string method = "Canceled";
            string method2 = "Returned";
            try
            {
                DBConnection DB = new DBConnection();
                DB.con.Open();
                SqlCommand cmd = new SqlCommand("select *, cast(OrderTotalprice as decimal(10,2)) AS OrderTotal from testOrders2_tbl " +
                    "WHERE CustomerID = @username AND OrderStatus IN (@method, @method2)", DB.con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@method", method);
                cmd.Parameters.AddWithValue("@method2", method2);
                PrintOrderItems.DataSource = cmd.ExecuteReader();
                PrintOrderItems.DataBind();
                DB.con.Close();
                AllOrdersButton.ForeColor = Color.Blue;
                PendingButton.ForeColor = Color.Blue;
                ShippedButton.ForeColor = Color.Blue;
                CompletedButton.ForeColor = Color.Blue;
                CanceledButton.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}