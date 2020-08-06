using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doug
{
    public partial class Default : System.Web.UI.MasterPage
    {
        public String loggedInUser = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    loggedInUser = Session["User"].ToString();
                }
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Login.aspx");
        }
        //protected void DisplayProfile()
        //{
        //    try
        //    {
        //        using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
        //        {
        //            connection.Open();
        //            var sql = "Select * from Users";
        //            var cmd = new SqlCommand(sql, connection);

        //            using (var dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {

        //                    {

        //                        Username.Text = dr["Username"].ToString();



        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
    }
}