using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype.ASPX
{

    public partial class UserProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Convert.ToString(Session["username"]);
            if (!Page.IsPostBack)
            {
                DBConnection DB = new DBConnection();
                try
                {
                    DB.con.Open();
                    SqlCommand cmd = new SqlCommand("select * from customer_tbl where CustomerID=@user", DB.con);
                    cmd.Parameters.AddWithValue("@user", username);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            UsernameTxtBox.Text = dr.GetString(5);
                            FName.Text = dr.GetString(0);
                            LName.Text = dr.GetString(1);
                            Street.Text = dr.GetString(2);
                            City.Text = dr.GetString(3);
                            Phone.Text = dr.GetValue(4).ToString();
                            Email.Text = dr.GetString(7);

                            Session["email"] = dr.GetValue(7).ToString();
                        }
                    }
                    DB.con.Close();
                    edit.Visible = true;
                    update.Visible = false;
                    FName.ReadOnly = true;
                    LName.ReadOnly = true;
                    Phone.ReadOnly = true;
                    Street.ReadOnly = true;
                    City.ReadOnly = true;
                    Email.ReadOnly = true;
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            edit.Visible = false;
            update.Visible = true;
            FName.ReadOnly = false;
            LName.ReadOnly = false;
            Phone.ReadOnly = false;
            Street.ReadOnly = false;
            City.ReadOnly = false;
            Email.ReadOnly = false;
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            DBConnection DB = new DBConnection();

            if (DB.con.State == System.Data.ConnectionState.Closed)
            {
                DB.con.Open();
            }

            SqlCommand cmd = new SqlCommand("UPDATE customer_tbl set FirstName = @fname, LastName = @lname, Street = @street, " +
                "City = @city, Phone = @phone, Email = @email WHERE CustomerID=@user", DB.con);

            cmd.Parameters.AddWithValue("@user", Convert.ToString(Session["username"]));
            cmd.Parameters.AddWithValue("@fname", FName.Text);
            cmd.Parameters.AddWithValue("@lname", LName.Text);
            cmd.Parameters.AddWithValue("@street", Street.Text);
            cmd.Parameters.AddWithValue("@city", City.Text);
            cmd.Parameters.AddWithValue("@phone", Phone.Text);
            cmd.Parameters.AddWithValue("@email", Email.Text);

            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Configured successfully!');</script>");
            DB.con.Close();

            UsernameTxtBox.Text = "";
            FName.Text = "";
            LName.Text = "";
            Street.Text = "";
            City.Text = "";
            Phone.Text = "";
            Email.Text = "";

            edit.Visible = true;
            update.Visible = false;
            FName.ReadOnly = true;
            LName.ReadOnly = true;
            Phone.ReadOnly = true;
            Street.ReadOnly = true;
            City.ReadOnly = true;
            Email.ReadOnly = true;
            Response.Redirect("UserProfilePage.aspx");
        }
    }
}