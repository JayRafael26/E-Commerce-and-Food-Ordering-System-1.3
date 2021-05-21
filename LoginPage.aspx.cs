using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = "login";
        }

        public bool CheckPassword(string unhashedPassword, string username)
        {
            string savedHashedPassword = "";
            DBConnection DB = new DBConnection();
            DB.con.Open();

            SqlCommand cmd = new SqlCommand("select * from customer_tbl where CustomerID= @username", DB.con);
            cmd.Parameters.AddWithValue("@username", username);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    savedHashedPassword = dr.GetValue(6).ToString();
                    return Crypto.VerifyHashedPassword(savedHashedPassword, unhashedPassword);
                }
            }

            return Crypto.VerifyHashedPassword(savedHashedPassword, unhashedPassword);
        }

        protected void LoginSubmit_Click(object sender, EventArgs e)
        {
            string username1 = UsernameTxtBox.Text.Trim();
            string password1 = PasswordTxtBox.Text.Trim();
            DBConnection DB = new DBConnection();
            if (username1.Equals("AdminTester123") && password1.Equals("P@$$w0rd"))
            {
                Session["role"] = "admin";
                Response.Redirect("AdminItemManagement.aspx");
            }
            else
            {
                try
                {
                    if (DB.con.State == System.Data.ConnectionState.Closed)
                    {
                        DB.con.Open();
                    }
                    bool verifyPassword = CheckPassword(password1, username1);
                    if(verifyPassword == true)
                    {
                        SqlCommand cmd = new SqlCommand("select * from customer_tbl where CustomerID= @username", DB.con);
                        cmd.Parameters.AddWithValue("@username", username1);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Session["street"] = dr.GetValue(2).ToString();
                                Session["city"] = dr.GetValue(3).ToString();
                                Session["phone"] = dr.GetValue(4).ToString();
                                Session["password"] = dr.GetValue(6).ToString();
                                Session["username"] = dr.GetValue(5).ToString();
                                Session["email"] = dr.GetValue(7).ToString();
                                string firstname = dr.GetValue(0).ToString();
                                Session["fname"] = firstname;
                                string lastname = dr.GetValue(1).ToString();
                                Session["lname"] = lastname;
                                string fullname = firstname + " " + lastname;
                                Session["fullname"] = fullname;
                                Session["role"] = "user";

                                //get details to store in the CartTable
                                DateTime localDate = DateTime.Now;
                                string username = Session["username"].ToString();
                                string dateTime = localDate.ToString("g");

                                //Set the cart details for this user, para isang cartID
                                bool checker = checkUserCartID(username);
                                if (checker == true)// checks kung may cart ID na yung user before
                                {
                                    //Do nothing kasi dun sa checker na set na yung CartID
                                }
                                else
                                {
                                    int CartID = SetCartDetails(username, dateTime);
                                    Session["CartID"] = CartID;
                                }


                            }
                            firstPhrase.Text = "Login Successful!";
                            secondPhrase.Text = "Welcome, " + Session["fullname"].ToString();
                            tryagainButton.Visible = false;
                            closeButton.Visible = true;
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
                            upModal.Update();

                        }
                        else
                        {
                            firstPhrase.Text = "Wrong Username";
                            secondPhrase.Text = "";
                            tryagainButton.Visible = true;
                            closeButton.Visible = false;
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
                            upModal.Update();
                        }
                    }
                    else
                    {
                        firstPhrase.Text = "Invalid Username/Password";
                        secondPhrase.Text = "";
                        tryagainButton.Visible = true;
                        closeButton.Visible = false;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "LoginModal", "$('#LoginModal').modal();", true);
                        upModal.Update();
                    }
                    
                }
                catch (Exception ex)
                {

                }
            }
        }
        private static int SetCartDetails(string username, string dateTime) // used if wala pang cart ID si user or like nawala yung ID niya
        {
            int cartID = 0;
            string custID = username;
            string dateCart = dateTime;
            DBConnection DB = new DBConnection();
            //Method to create a CartID, and getting the date to store in the cart TBL
            try
            {
                SqlCommand insert = new SqlCommand("INSERT INTO testCart2(CartCustomerID, CartDate) output INSERTED.CartID values (@cartCustID, @cartDate)", DB.con);
                insert.Parameters.AddWithValue("@cartCustID", custID);
                insert.Parameters.AddWithValue("@cartDate", dateCart);

                DB.con.Open();
                cartID = (int)insert.ExecuteScalar();
                DB.con.Close();

                return cartID;
            }
            catch (Exception ea)
            {
                return cartID;
                //Response.Write("<script>alert('" + ea.Message + "'); </script>");

            }
        }

        private static bool checkUserCartID(string username) // checks if the user already has a UserCartID or not para alam kung gagawan or magrerefer na lang don
        {
            string custID = username;
            bool check = false;
            DBConnection DB = new DBConnection();
            DB.con.Open();
            //Method to create a CartID, and getting the date to store in the cart TBL
            try
            {
                SqlCommand cmd = new SqlCommand("select * from testCart2 where CartCustomerID='" + username + "'", DB.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        check = true;
                        System.Web.HttpContext.Current.Session["CartID"] = dr.GetValue(0);
                        return check;
                    }
                }
                return check;
            }
            catch (Exception ea)
            {
                return check;
                //Response.Write("<script>alert('" + ea.Message + "'); </script>");

            }
        }


        protected void CloseButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}