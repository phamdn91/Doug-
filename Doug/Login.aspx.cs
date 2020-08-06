using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace Doug
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
            else
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    var sql = "Select * from Users";
                    var cmd = new SqlCommand(sql, connection);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var UserName = dr["Username"].ToString();
                            var Password = dr["Password"].ToString();
                            if (dr["Username"].ToString() == txtUsername.Text
                                && dr["Password"].ToString() == txtPassword.Text)
                            {
                                Session["User"] = txtUsername.Text;
                                Response.Redirect("/Dashboard/Default.aspx");
                            }
                            else
                            {
                                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Incorrect Username and/or Password.');", true);
                                //Response.Redirect("/Login.aspx");
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