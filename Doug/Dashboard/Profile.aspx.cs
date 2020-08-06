using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doug.Dashboard
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {


            }
            else

            {
                DisplayProfile();
            }
        }
        protected void DisplayProfile()
        {
            
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    //var sql = "Select * from Users Where [Username] = @Name Order by id DESC";
                    var sql = "Select * from Users";

                    var cmd = new SqlCommand(sql, connection);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            System.Diagnostics.Debug.WriteLine("help me1.3");


                            //var name = Session["User"].ToString();
                            //DateTime currentDateTime = System.DateTime.Now;
                            //DateTime updatedDateTime = new DateTime();
                            //updatedDateTime = (DateTime)dr["UpdatedDateTime"];

                            var userName = dr["Username"].ToString();
                            if (userName == Session["User"].ToString())
                            //if (currentDateTime.Day < updatedDateTime.Day)
                            {
                                FirstName.Text = dr["FirstName"].ToString();
                                LastName.Text = dr["LastName"].ToString();
                                Email.Text = dr["Email"].ToString();
                                UserName.Text = dr["Username"].ToString();
                                //Password.Text = dr["Password"].ToString();
                                //ConfirmPassword.Text = dr["ConfirmPassword"].ToString();


                                //display user information to page hint(asp:textbox and firstname.value = dr["FirstName"]
                            }
                        }

                        }
                    }
                
            }
            catch
            {

            }

        }


        protected void btnProfile_Click(object sender, EventArgs e)
        {
            {


                try
                {

                    using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                    {
                        connection.Open();
                        var name = Session["User"].ToString();

                        SqlCommand cmd = new SqlCommand("UPDATE Users SET [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email, [UserName] = @UserName, [Password] = @Password WHERE [Username] = @Name", connection);

                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastName.Text);
                        cmd.Parameters.AddWithValue("@Email", Email.Text);
                        cmd.Parameters.AddWithValue("@UserName", UserName.Text);
                        cmd.Parameters.AddWithValue("@Password", Password.Text);




                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }


                }

                catch
                {

                }
            }
        }
    }
}