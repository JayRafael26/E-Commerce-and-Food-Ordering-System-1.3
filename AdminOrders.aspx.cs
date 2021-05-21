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
    public partial class AdminOrders : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GridBindData();
            }
            catch (Exception ex)
            {
            }
        }

        protected void GridBindData()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter cmd = new SqlDataAdapter("SELECT OrderID, OrderDate, OrderStatus, CustomerID from testOrders2_tbl ORDER by OrderID DESC;", con);

            DataSet ds = new DataSet();
            cmd.Fill(ds);
            OrderDataGrid.DataSource = ds;
            OrderDataGrid.DataBind();
            backButton.Visible = false;
            con.Close();
        }

        protected void SearchItem_Click(object sender, EventArgs e)
        {
            string sidHolder;
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT OrderID, OrderDate, OrderStatus, CustomerID FROM testOrders2_tbl WHERE OrderID =  @sid;", con);
                cmd.SelectCommand.Parameters.AddWithValue("@sid", itemSearch.Text.Trim());

                sidHolder = itemSearch.Text.Trim();
                Session["searchOid"] = itemSearch.Text.Trim();
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                OrderDataGrid.DataSource = ds;
                OrderDataGrid.DataBind();
                backButton.Visible = true;
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        protected void AllOrders_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT OrderID, OrderDate, OrderStatus from testOrders2_tbl ORDER by OrderID DESC;", con);

                DataSet ds = new DataSet();
                cmd.Fill(ds);
                OrderDataGrid.DataSource = ds;
                OrderDataGrid.DataBind();

                con.Close();
                //Response.Write(sidHolder);
            }
            catch (Exception ex)
            {

            }
        }

        protected void ViewOrder_Click(object sender, EventArgs e)
        {
            if (itemSearch.Text != "")
            {
                Session["searchOid"] = itemSearch.Text.Trim();
                Response.Redirect("adminCheckOrder.aspx");
            }
            else
            {
                Response.Write("<script>alert('Input an Order ID to search first.');</script>");
            }
        }

        protected void Grid_Change(object sender, DataGridPageChangedEventArgs e)
        {
            OrderDataGrid.CurrentPageIndex = e.NewPageIndex;
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT OrderID, OrderDate, OrderStatus from testOrders2_tbl ORDER by OrderID DESC;", con);

            DataSet ds = new DataSet();
            cmd.Fill(ds);
            OrderDataGrid.DataSource = ds;
            OrderDataGrid.DataBind();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOrders.aspx");
        }
    }
}
