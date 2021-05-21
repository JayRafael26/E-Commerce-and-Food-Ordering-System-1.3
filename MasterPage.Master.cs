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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        { 
            try
            {
                if (Session["role"] != null)
                {
                    if (Session["role"].Equals("user"))
                    {
                        disabledCart.Visible = false;
                        accountDropdown.Visible = true;
                        loginButton.Visible = false;
                        CartButton1.Visible = true;
                        ResellersButton.Visible = true;
                        HelpButton.Visible = true;
                        ChickenButton.Visible = true;
                        BeefButton.Visible = true;
                        OtherProdButton.Visible = true;
                        QuezonCityButton.Visible = true;
                        BusinessProfButton.Visible = true;
                        UserOrders.Visible = true;
                        userProfileButton.Visible = true;

                        //admin functions
                        AdminDashboard.Visible = false;
                        ItemManagement.Visible = false;
                        AdminOrders.Visible = false;

                        int counter = CheckCartCount();
                        cartCounter.Text = counter.ToString();

                    }
                    else if (Session["role"].Equals("admin"))
                    {
                        //May add pa dito na buttons na only admin can see
                        //to be added kapag nagawa na ni mikwal yung front end
                        //disabledCart.Visible = false;
                        accountDropdown.Visible = true;
                        loginButton.Visible = false;
                        CartButton1.Visible = false;
                        ResellersButton.Visible = false;
                        HelpButton.Visible = false;
                        ChickenButton.Visible = true;
                        BeefButton.Visible = true;
                        OtherProdButton.Visible = true;
                        QuezonCityButton.Visible = false;
                        BusinessProfButton.Visible = false;
                        contactDropdown.Visible = false;
                        aboutUsDropdown.Visible = false;
                        UserOrders.Visible = false;
                        userProfileButton.Visible = false;

                        AdminDashboard.Visible = true;
                        ItemManagement.Visible = true;
                        AdminOrders.Visible = true;
                    }
                    else
                    {
                        //disabledCart.Visible = true;
                        accountDropdown.Visible = false;
                        loginButton.Visible = true;
                        CartButton1.Visible = false;
                        ResellersButton.Visible = true;
                        HelpButton.Visible = true;
                        ChickenButton.Visible = true;
                        BeefButton.Visible = true;
                        OtherProdButton.Visible = true;
                        QuezonCityButton.Visible = true;
                        BusinessProfButton.Visible = true;
                        userProfileButton.Visible = false;
                        UserOrders.Visible = false;

                        //admin functions
                        AdminDashboard.Visible = false;
                        ItemManagement.Visible = false;
                        AdminOrders.Visible = false;
                    }
                }
                else
                {
                    //disabledCart.Visible = true;
                    accountDropdown.Visible = false;
                    loginButton.Visible = true;
                    CartButton1.Visible = false;
                    ResellersButton.Visible = true;
                    HelpButton.Visible = true;
                    ChickenButton.Visible = true;
                    BeefButton.Visible = true;
                    OtherProdButton.Visible = true;
                    QuezonCityButton.Visible = true;
                    BusinessProfButton.Visible = true;
                    UserOrders.Visible = false;

                    AdminDashboard.Visible = false;
                    ItemManagement.Visible = false;
                    AdminOrders.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
       
        }
        protected static int CheckCartCount()
        {
            string CartID = System.Web.HttpContext.Current.Session["CartID"].ToString();
            int counter = 0;
            DBConnection DB = new DBConnection();
            DB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(CartItemID) FROM testCartItems WHERE CartID = @cartid", DB.con);
                cmd.Parameters.AddWithValue("@cartid", CartID);
                counter = Convert.ToInt32(cmd.ExecuteScalar());
                System.Web.HttpContext.Current.Session["cartCounter"] = counter;
                DB.con.Close();
                return counter;
            }
            catch
            {
                DB.con.Close();
                return counter;
            }
        }


        protected void LogoutAccount(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["CartID"] = "";
            Response.Redirect("HomePage.aspx");
            Session["UpdateCart"] = "";
            Session["TotalCartPrice"] = "";
            Session["OrderToView"] = "";
        }
        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void CartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }

        protected void ResellersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResellersPage.aspx");
        }

        protected void HelpButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("HelpPage.aspx");
        }

        protected void ChickenButton_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ChickenPage.aspx");
        }

        protected void  BeefButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("BeefPage.aspx");
        }

        protected void OtherProdButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("OtherProductsPage.aspx");
        }

        protected void QuezonCityButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUsPage.aspx");
        }
        protected void BusinessProfButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutUsPage.aspx");
        }
        protected void UserProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfilePage.aspx");
        }
        protected void AdminDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomepage.aspx");
        }
        protected void ItemManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminItemManagement.aspx");
        }
        protected void AdminOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOrders.aspx");
        }
        protected void UserOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserOrders.aspx");
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            string searchItem = SearchThis.Text;
            Session["SearchItem"] = searchItem;
            Response.Redirect("SearchPage.aspx");
        }
        
    }
}