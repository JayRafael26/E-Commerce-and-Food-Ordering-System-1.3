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

namespace MangAtongsPrototype.ASPX
{
    public partial class AdminItemManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter cmd = new SqlDataAdapter("SELECT ProductID, ProductPrice, ProductName, ProductQuantity, CategoryID FROM products_tbl;", con);

                DataSet ds = new DataSet();
                cmd.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

                AllProducts.ForeColor = Color.Gray;
                ChickenButton.ForeColor = Color.Blue;
                BeefButton.ForeColor = Color.Blue;
                OthersButton.ForeColor = Color.Blue;

                con.Close();
                backButton.Visible = false;
                //  Response.Write("naglist pre");
            }
            catch (Exception ex)
            {

            }


        }
        //code for when users clicks search
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

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT ProductID, ProductPrice, ProductName, ProductQuantity, CategoryID FROM products_tbl WHERE ProductID =  @sid;", con);
                cmd.SelectCommand.Parameters.AddWithValue("@sid", itemSearch.Text.Trim());

                sidHolder = itemSearch.Text.Trim();
                Session["searchid"] = itemSearch.Text.Trim();
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                backButton.Visible = true;
                con.Close();
                //Response.Write(sidHolder);
            }
            catch (Exception ex)
            {

            }
        }

        protected void DeleteItem_Click(object sender, EventArgs e)
        {
            if (itemSearch.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string sid = itemSearch.Text.Trim();
                    SqlCommand cmd = new SqlCommand("DELETE FROM products_tbl WHERE ProductID = @sid;", con);
                    cmd.Parameters.AddWithValue("@sid", sid);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    firstPhrase.Text = "You have successfully deleted the item.";
                    Proceed.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AdminItemManagementModal", "$('#AdminItemManagementModal').modal();", true);
                    upModal.Update();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                firstPhrase.Text = "Input a ProductID to search first.";
                Proceed.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AdminItemManagementModal", "$('#AdminItemManagementModal').modal();", true);
                upModal.Update();
            }
        }

        protected void UpdateItem_Click(object sender, EventArgs e)
        {
            if (itemSearch.Text != "")
            {
                Session["searchid"] = itemSearch.Text.Trim();
                Response.Redirect("AdminUpdateItem.aspx");
            }
            else
            {
                firstPhrase.Text = "Input a ProductID to search first.";
                Proceed.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AdminItemManagementModal", "$('#AdminItemManagementModal').modal();", true);
                upModal.Update();
            }
        }


        protected void AllProducts_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT ProductID, ProductPrice, ProductName, ProductQuantity, CategoryID FROM products_tbl", con);

                DataSet ds = new DataSet();
                cmd.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

                AllProducts.ForeColor = Color.Gray;
                ChickenButton.ForeColor = Color.Blue;
                BeefButton.ForeColor = Color.Blue;
                OthersButton.ForeColor = Color.Blue;

                con.Close();
                //Response.Write(sidHolder);
            }
            catch (Exception ex)
            {

            }
        }
        protected void Chicken_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT ProductID, ProductPrice, ProductName, ProductQuantity, CategoryID FROM products_tbl WHERE CategoryID =  1;", con);

                DataSet ds = new DataSet();
                cmd.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

                AllProducts.ForeColor = Color.Blue;
                ChickenButton.ForeColor = Color.Gray;
                BeefButton.ForeColor = Color.Blue;
                OthersButton.ForeColor = Color.Blue;

                con.Close();
                //Response.Write(sidHolder);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Beef_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT ProductID, ProductPrice, ProductName, ProductQuantity, CategoryID FROM products_tbl WHERE CategoryID =  2;", con);

                DataSet ds = new DataSet();
                cmd.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

                AllProducts.ForeColor = Color.Blue;
                ChickenButton.ForeColor = Color.Blue;
                BeefButton.ForeColor = Color.Gray;
                OthersButton.ForeColor = Color.Blue;

                con.Close();
                //Response.Write(sidHolder);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Others_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter cmd = new SqlDataAdapter("SELECT ProductID, ProductPrice, ProductName, ProductQuantity, CategoryID FROM products_tbl WHERE CategoryID =  3;", con);

                DataSet ds = new DataSet();
                cmd.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

                AllProducts.ForeColor = Color.Blue;
                ChickenButton.ForeColor = Color.Blue;
                BeefButton.ForeColor = Color.Blue;
                OthersButton.ForeColor = Color.Gray;


                con.Close();
                //Response.Write(sidHolder);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminItemManagement.aspx");
        }

        protected void Proceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminItemManagement.aspx");
        }
    }
}