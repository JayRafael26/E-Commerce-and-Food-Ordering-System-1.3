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
    public partial class HelpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (String.IsNullOrEmpty(Session["email"] as String))
            {

                Response.Write("<script>alert('You must create an account or login first');</script>");
            }
            else
            {
                UserEmail.Value = Session["email"].ToString();
            }*/
        }

        /*protected void SubmitQuery_Click(object sender, EventArgs e)
        {
            DBConnection DB = new DBConnection();
            try
            {
                if (DB.con.State == System.Data.ConnectionState.Closed)
                {
                    DB.con.Open();
                }


                SqlCommand cmd = new SqlCommand("INSERT INTO test_tbl(CustomerID, Email, Query) values (@customer, @email, @query)", DB.con);

                cmd.Parameters.AddWithValue("@customer", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@email", UserEmail.Value);
                cmd.Parameters.AddWithValue("@query", UserQuery.Value);


                cmd.ExecuteNonQuery();
                DB.con.Close();

                Response.Write("<script>alert('Query Submitted');</script>");
                UserQuery.Value = "";
            }

            catch (Exception ex)
            {

            }
        }*/
    }
}