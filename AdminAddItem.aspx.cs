using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype.ASPX
{
    public partial class AdminAddItem : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO products_tbl(ProductPrice, ProductName, ProductQuantity, ProductDescription, CategoryID, ImagePath) values (@itemprice, @itemname, @itemqty, @itemdesc, @itemID, @itemimage)", con);

                string imagename = ItemImage.FileName.ToString();
                if (imagename == "")
                {
                    firstPhrase.Text = "An image must be uploaded";
                    Proceed.Visible = false;
                    Close.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddItem", "$('#AddItem').modal();", true);
                    upModal.Update();
                }
                else
                {
                    ItemImage.PostedFile.SaveAs(Server.MapPath("images/") + imagename);
                    cmd.Parameters.AddWithValue("@itemname", itemName.Text.Trim());
                    cmd.Parameters.AddWithValue("@itemdesc", itemDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@itemprice", itemPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@itemqty", itemQty.Text.Trim());
                    cmd.Parameters.AddWithValue("@itemID", ctgID.SelectedValue);
                    cmd.Parameters.AddWithValue("@itemimage", "images/" + imagename);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    firstPhrase.Text = "Successfully Inserted " + itemName.Text.Trim();
                    Proceed.Visible = true;
                    Close.Visible = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AddItem", "$('#AddItem').modal();", true);
                    upModal.Update();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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