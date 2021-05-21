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
    public partial class AdminUpdateItem : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sid = Session["searchid"].ToString();
            //   Response.Write(sid);
            hold.Text = sid;
            if (!IsPostBack)
            {

                //select all and display the necessary details based on sid
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * FROM products_tbl WHERE ProductID = @sid; ", con);
                    cmd.Parameters.AddWithValue("@sid", hold.Text.Trim());
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        itemDescription.Text = dr.GetString(5);
                        itemName.Text = dr.GetString(2);
                        itemPrice.Text = dr.GetValue(1).ToString();
                        itemQty.Text = dr.GetValue(3).ToString();
                        ctgID.SelectedValue = dr.GetValue(4).ToString();
                    }

                    //   Response.Write(dr.GetString(5));

                    con.Close();
                }
                catch (Exception ex)
                {

                }
            }

        }

        protected void UpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE products_tbl set ProductDescription =@itemdesc, ProductPrice =@itemprice, ProductName =@itemname, ProductQuantity =@itemqty, CategoryID = @ctgID, ImagePath = @itemimage WHERE (ProductID =@sid)", con);

                string imagename = ItemImage.FileName.ToString();
                ItemImage.PostedFile.SaveAs(Server.MapPath("images/") + imagename);
                cmd.Parameters.AddWithValue("@sid", hold.Text.Trim());
                cmd.Parameters.AddWithValue("@itemname", itemName.Text.Trim());
                cmd.Parameters.AddWithValue("@itemdesc", itemDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@itemprice", itemPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@itemqty", itemQty.Text.Trim());
                cmd.Parameters.AddWithValue("@ctgID", ctgID.SelectedValue);
                cmd.Parameters.AddWithValue("@itemimage", "images/" + imagename);

                cmd.ExecuteNonQuery();
                con.Close();
                firstPhrase.Text = "Successfully Updated " + itemName.Text.Trim();
                Proceed.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "UpdateItem", "$('#UpdateItem').modal();", true);
                upModal.Update();
            }
            catch (Exception ex)
            {

            }

        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminItemManagement.aspx");
        }
        protected void Proceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminItemManagement.aspx");
        }
    }
}