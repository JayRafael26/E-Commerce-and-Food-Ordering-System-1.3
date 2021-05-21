using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangAtongsPrototype
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            protected void RegisterSubmit_Click(object sender, EventArgs e)
        {
            DBConnection DB = new DBConnection();
            string Regusername = UsernameTxtBox.Text.Trim();
            string Regfname = FNameTxtBox.Text.Trim();
            string Reglname = LNameTxtBox.Text.Trim();
            string Regstreet = StreetTxtBox.Text.Trim();
            string Regcity = CityTxtBox.Text.Trim();
            string regphone = ContactTxtBox.Text.Trim();
            string regpass = PasswordTxtBox.Text.Trim();
            string regemail = EmailAddressTxtBox.Text.Trim();
            bool checkContact, checkEmail, checkPass;
            try
            {
                if (string.IsNullOrWhiteSpace(Regusername) == false && string.IsNullOrWhiteSpace(Regfname) == false && string.IsNullOrWhiteSpace(Reglname) == false
                    && string.IsNullOrWhiteSpace(Regstreet) == false && string.IsNullOrWhiteSpace(Regcity) == false && string.IsNullOrWhiteSpace(regphone) == false
                    && string.IsNullOrWhiteSpace(regpass) == false && string.IsNullOrWhiteSpace(regemail) == false) //makes sure that form is not empty
                {
                    if (Regusername == "AdminTester123")
                    {
                        firstPhrase.Text = "Username already Taken";
                        secondPhrase.Text = "";
                        tryagainButton.Visible = true;
                        closeButton.Visible = false;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterModal", "$('#RegisterModal').modal();", true);
                        upModal.Update();
                    }
                    else
                    {
                        checkPass = isStrongPassword(regpass);
                        if (checkPass == true)
                        {
                            checkContact = IsPhoneNumber(regphone);
                            checkEmail = IsEmailAddress(regemail);
                            if (regphone.Length == 11 && checkContact == true)
                            {
                                if(checkEmail == true)
                                {
                                    DB.con.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO customer_tbl(FirstName, LastName, Street, City, Phone, CustomerID, pass, Email) values (@fname, @lname, @street, @city, @phone, @cid, @password, @email)", DB.con);

                                    cmd.Parameters.AddWithValue("@fname", Regfname);
                                    cmd.Parameters.AddWithValue("@lname", Reglname);
                                    cmd.Parameters.AddWithValue("@street", Regstreet);
                                    cmd.Parameters.AddWithValue("@city", Regcity);
                                    cmd.Parameters.AddWithValue("@phone", regphone);
                                    cmd.Parameters.AddWithValue("@cid", Regusername);
                                    cmd.Parameters.AddWithValue("@password", GenerateHashPass(regpass));
                                    cmd.Parameters.AddWithValue("@email", regemail);

                                    cmd.ExecuteNonQuery();
                                    DB.con.Close();
                                    firstPhrase.Text = "You have registered successfully!";
                                    secondPhrase.Text = "";
                                    thirdPhrase.Text = "";
                                    samplePass.Text = "";
                                    tryagainButton.Visible = false;
                                    closeButton.Visible = true;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterModal", "$('#RegisterModal').modal();", true);
                                    upModal.Update();
                                }
                                else
                                {
                                    firstPhrase.Text = "Please input a valid Email Address.";
                                    secondPhrase.Text = "";
                                    thirdPhrase.Text = "";
                                    samplePass.Text = "";
                                    tryagainButton.Visible = true;
                                    closeButton.Visible = false;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterModal", "$('#RegisterModal').modal();", true);
                                    upModal.Update();
                                }
                                
                            }
                            else
                            {
                                firstPhrase.Text = "Contact No. must be 11 digits and comprised of Numbers.";
                                secondPhrase.Text = "";
                                thirdPhrase.Text = "";
                                samplePass.Text = "";
                                tryagainButton.Visible = true;
                                closeButton.Visible = false;
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterModal", "$('#RegisterModal').modal();", true);
                                upModal.Update();
                            }
                        }
                        else //else for checking ano kulang sa password
                        {
                            passwordErrors(regpass);
                        }
                    }
                }
                else
                {
                    checkforErrors();
                }
            }
            catch (Exception ex)
            {
                firstPhrase.Text = "This username is already taken.";
                secondPhrase.Text = "";
                tryagainButton.Visible = true;
                closeButton.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterModal", "$('#RegisterModal').modal();", true);
                upModal.Update();
            }
        }
        protected void checkforErrors()
        {
            string errors = "";
            if (FNameTxtBox.Text.Trim().Equals("") || LNameTxtBox.Text.Trim().Equals("") || StreetTxtBox.Text.Trim().Equals("") || CityTxtBox.Text.Trim().Equals("") ||
                ContactTxtBox.Text.Trim().Equals("") || UsernameTxtBox.Text.Trim().Equals("") || PasswordTxtBox.Text.Trim().Equals(""))
            {
                if (FNameTxtBox.Text.Trim().Equals(""))
                {
                    errors += "First Name" + ",";
                }
                if (LNameTxtBox.Text.Trim().Equals(""))
                {
                    errors += "Last Name" + ",";
                }
                if (StreetTxtBox.Text.Trim().Equals(""))
                {
                    errors += "Street" + ",";
                }
                if (CityTxtBox.Text.Trim().Equals(""))
                {
                    errors += "City" + ",";
                }
                if (ContactTxtBox.Text.Trim().Equals(""))
                {
                    errors += "Contact No." + ",";
                }
                if (UsernameTxtBox.Text.Trim().Equals(""))
                {
                    errors += "Username" + ",";
                }
                if (PasswordTxtBox.Text.Trim().Equals(""))
                {
                    errors += "Password";
                }
                Response.Write("<script>alert('Please input your " + errors + "');</script>");
                //gawin tong modal popup
            }
            else
            {
                UsernameTxtBox.Text = string.Empty;
                Response.Write("<script>alert('Username is already taken');</script>");
            }
        }

        protected bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{11})$").Success;
        }
        protected bool IsEmailAddress(string email)
        {
            return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }

        protected bool isStrongPassword(string password)
        {
            //return Regex.Match(password, @"^(?=.*[A - Z]{1,})(?=.*[!@#$&*]{1,})(?=.*[0-9]{2,})(?=.*[a-z]{3,})$").Success;
            return Regex.Match(password, @"^(?=.*[A-Z]{1,})(?=.*[a-z]{1,})(?=.*[0-9]{1,})(?=.*[~!@#$%^&*()\-_=+{};:,<.>]{1,}).{8,}$").Success;
        }

        protected void passwordErrors(string password)
        {
            bool checkUppercase, checkSpecialChar, checkDigits, checkLowercase, checkLength;
            checkUppercase = hasUpper(password);
            checkSpecialChar = hasSpecial(password);
            checkDigits = hasDigits(password);
            checkLowercase = hasLower(password);
            checkLength = isLong(password);
            string passworderrors = "";
            if (checkUppercase == false)
            {
                passworderrors += "1 Uppercase Letter or more <br/>";
            }
            if (checkSpecialChar == false)
            {
                passworderrors += "1 Special Character or more <br/>";
            }
            if (checkDigits == false)
            {
                passworderrors += "2 Numbers or more <br/>";
            }
            if (checkLowercase == false)
            {
                passworderrors += "3 Lowercase Letters or more <br/>";
            }
            if (checkLength == false)
            {
                passworderrors += "8 Characters or more <br/>";
            }
            firstPhrase.Text = "Invalid Password. Your password must have:";
            secondPhrase.Text = passworderrors;
            thirdPhrase.Text = "Sample Valid Password: ";
            samplePass.Text = "!SamplePass261 or 24!Sample";
            secondPhrase.ForeColor = Color.Red;
            samplePass.ForeColor = Color.Green;
            tryagainButton.Visible = true;
            closeButton.Visible = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterModal", "$('#RegisterModal').modal();", true);
            upModal.Update();
        }

        protected bool hasUpper(string password)
        {
            return Regex.Match(password, @"^(.*?[A-Z]){1,}.*$").Success;
        }
        protected bool hasSpecial(string password)
        {
            return Regex.Match(password, @"^(.*?[~!@#$%^&*()\-_=+{};:,<.>]){1,}.*$").Success;
        }
        protected bool hasDigits(string password)
        {
            return Regex.Match(password, @"^(.*?[0-9]){1,}.*$").Success;
        }
        protected bool hasLower(string password)
        {
            return Regex.Match(password, @"^(.*?[a-z]){1,}.*$").Success;
        }
        protected bool isLong(string password)
        {
            return Regex.Match(password, @"^{8,}$").Success;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            UsernameTxtBox.Text = "";
            FNameTxtBox.Text = string.Empty;
            FNameTxtBox.Text = string.Empty;
            StreetTxtBox.Text = string.Empty;
            CPasswordTxtBox.Text = "";
            CityTxtBox.Text = string.Empty;
            ContactTxtBox.Text = string.Empty;
            PasswordTxtBox.Text = string.Empty;
            EmailAddressTxtBox.Text = string.Empty;
        }

        /*private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }*/

        /*protected string[] GetHashPassword(string password)
        {
            string[] pass = new string[2];
            string hashPass = string.Empty;

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[20]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[40];
            Array.Copy(salt, 0, hashBytes, 0, 20);
            Array.Copy(hash, 0, hashBytes, 20, 20);

            hashPass = Convert.ToBase64String(hashBytes);
            string s = Convert.ToBase64String(salt);
            pass[0] = hashPass;
            pass[1] = s;
            return pass;
        }*/
        public string GenerateHashPass(string password)
        {
            string hashedPassword = Crypto.HashPassword(password);
            Response.Write(hashedPassword.Length);
            return hashedPassword;
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}