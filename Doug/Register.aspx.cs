using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doug
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var count = 0;

                using (
                    var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    bool exists = false;

                    using (SqlCommand cmd = new SqlCommand("select count(*) from [Users] where UserName = @UserName", connection))
                    {
                        cmd.Parameters.AddWithValue("UserName", txtUsername.Text);
                        exists = (int)cmd.ExecuteScalar() > 0;
                    }

                    if (exists)
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('This username is not available - please try another.');", true);

                    else
                    {

                        var sql = "INSERT INTO Users (FirstName, LastName, Email, Username, Password, UpdatedDateTime) values (@FirstName, @LastName, @Email, @Username, @Password, @UpdatedDateTime)";

                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("UpdatedDateTime", System.DateTime.Now);
                        cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("UserName", txtUsername.Text);
                        cmd.Parameters.AddWithValue("Password", txtPassword.Text);

                        {



                            count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {

                                Response.Redirect("/Login.aspx");

                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}