using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doug.Dashboard
{
    public partial class Table : System.Web.UI.Page
    {
        protected List<int> dates = new List<int>();
        protected List<int> calories = new List<int>();
        protected List<int> activities = new List<int>();
        protected List<int> weights = new List<int>();
        protected List<int> body_fat = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //lbDate.Text = All_Dates().ToString();
            //lbCalories.Text = All_Calories().ToString();
            //lbActivity.Text = All_Activities().ToString();
            //lbWeight.Text = All_Weights().ToString();
            //lbBodyFat.Text = All_Body_Fats().ToString();
            All_Calories();
        }

        public void calorieConvertToJSON()
        {
            JavaScriptSerializer jss1 = new JavaScriptSerializer();

            string calorieString = jss1.Serialize(calories);
            string point = "var point=" + calorieString + ";";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "point", point, true);

        }

        protected void All_Calories()
        {
            var name = Session["User"];
            //List<int> calories = new List<int>();
            try
            {

                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    var sql = "Select all from Diary Where [Username] = @Name Order By UpdatedDateTime ASC ";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    using (var dr = cmd.ExecuteReader())

                    {
                        while (dr.Read())
                        {
                            calories.Add((int)dr["Calorie"]);

                        }

                    }
                }
                calorieConvertToJSON();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
        }

    }

}