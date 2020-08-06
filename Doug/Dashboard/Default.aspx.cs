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
    
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dayofdate = System.DateTime.Now.ToString("dddd");
            System.Diagnostics.Debug.WriteLine("TIME OF DAY: "+dayofdate);
            if (dayofdate == "Monday")
            {
                lbDayOfTheWeek.Text = "Day 1 (Lower Focused Full Body)";
            }
            else if (dayofdate == "Tuesday")
            {
                lbDayOfTheWeek.Text = "Day 2 (Chest Focused Full Body)";

            }
            else if (dayofdate == "Wednesday")
            {
                lbDayOfTheWeek.Text = "Day 3 (Back Focused Full Body)";

            }
            else if (dayofdate == "Thursday")
            {
                lbDayOfTheWeek.Text = "Day 4 (Lower Focused Full Body)";

            }
            else if (dayofdate == "Friday")
            {
                lbDayOfTheWeek.Text = "Day 5 (Deltoid Focused Full Body)";

            }
            else
            {
                lbDayOfTheWeek.Text = "Rest Day";

            }
            Populate_Weight_Chart();
            Populate_Activity_Chart();
            lbCalorieIntake.Text = Calculate_Calories_Today().ToString();
            lbActivity.Text = Calculate_Activity_Today().ToString();
            lbCurrentWeight.Text = Calculate_CurrentWeight_Today().ToString();

        }

        protected int Calculate_CurrentWeight_Today()
        {
            int totalWeight = 0;
            using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                var name = Session["User"];
                connection.Open();
                var sql = "Select top 1 * from Stats Where [Username] = @Name order by Id DESC";

                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                DateTime currentDateTime = System.DateTime.Now;
                DateTime updatedDateTime = System.DateTime.Now;
                int todayWeight = 0;

                using (var dr = cmd.ExecuteReader())

                {
                    while (dr.Read())
                    {

                        todayWeight = (int)dr["Weight"];
                      
                        updatedDateTime = (DateTime)dr["UpdatedDateTime"];

                    }

                }

                if (currentDateTime.Date.CompareTo(updatedDateTime.Date) == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Current: " + currentDateTime.Date);
                    System.Diagnostics.Debug.WriteLine("Current: " + currentDateTime.Date);
                    totalWeight = todayWeight;
                }
            }

            return totalWeight;
        }
        protected int Calculate_Calories_Today()
        {
            int totalCalories = 0;
            using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                var name = Session["User"];
                connection.Open();
                //var sql = "select top 7 * from Activity where Username = " + Session["User"].ToString() + " order by id DESC";
                var sql = "Select top 1 * from Diary Where [Username] = @Name order by Id DESC";

                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                DateTime currentDateTime = System.DateTime.Now;
                DateTime updatedDateTime = System.DateTime.Now;
                int breakfastCalories = 0;
                int lunchCalories = 0;
                int dinnerCalories = 0;
                int snacksCalories = 0;
               
                using (var dr = cmd.ExecuteReader())
                  
                {
                    while (dr.Read())
                    {
                  
                        breakfastCalories = (int)dr["Breakfast"];
                        lunchCalories = (int)dr["Lunch"];
                        dinnerCalories = (int)dr["Dinner"];
                        snacksCalories = (int)dr["Snacks"];
                        updatedDateTime = (DateTime)dr["UpdatedDateTime"];

                    }

                }
                
                if(currentDateTime.Date.CompareTo(updatedDateTime.Date) == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Current: "+ currentDateTime.Date);
                    System.Diagnostics.Debug.WriteLine("Current: " + currentDateTime.Date);

                    totalCalories = breakfastCalories + lunchCalories + dinnerCalories + snacksCalories;
                }
            }

            return totalCalories;
        }
        protected List<int> bodyfat = new List<int>();
        protected List<int> weight = new List<int>();
        protected List<int> weightLifting = new List<int>();
        protected List<int> running = new List<int>();
        protected List<int> walking = new List<int>();
        protected List<int> other = new List<int>();

        protected int Calculate_Activity_Today()
        {
            int totalActivity = 0;
            using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                var name = Session["User"];
                connection.Open();
                //var sql = "select top 7 * from Activity where Username = " + Session["User"].ToString() + " order by id DESC";
                var sql = "Select top 1 * from Activity Where [Username] = @Name order by Id DESC";

                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                DateTime currentDateTime = System.DateTime.Now;
                DateTime updatedDateTime = System.DateTime.Now;
                int weightLiftingCalories = 0;
                int runningCalories = 0;
                int walkingCalories = 0;
                int otherCalories = 0;

                using (var dr = cmd.ExecuteReader())

                {
                    while (dr.Read())
                    {

                        weightLiftingCalories = (int)dr["WeightLifting"];
                        runningCalories = (int)dr["Running"];
                        walkingCalories = (int)dr["Walking"];
                        otherCalories = (int)dr["Other"];
                        updatedDateTime = (DateTime)dr["UpdatedDateTime"];

                    }

                }

                if (currentDateTime.Date.CompareTo(updatedDateTime.Date) == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Current: " + currentDateTime.Date);
                    System.Diagnostics.Debug.WriteLine("Current: " + currentDateTime.Date);

                    totalActivity = weightLiftingCalories + runningCalories + walkingCalories + otherCalories;
                }
            }

            return totalActivity;
        }

     

        public void activityConvertToJSON()
        {
            JavaScriptSerializer jss1 = new JavaScriptSerializer();
            string weightLiftingString = jss1.Serialize(weightLifting);
            string player = "var player=" + weightLiftingString + ";";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "player", player, true);

            string runningString = jss1.Serialize(running);
            string player1 = "var player1=" + runningString + ";";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "player1", player1, true);

            string walkingString = jss1.Serialize(walking);
            string player2 = "var player2=" + walkingString + ";";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "player2", player2, true);

            string otherString = jss1.Serialize(other);
            string player3 = "var player3=" + otherString + ";";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "player3", player3, true);
            //"var player1={1,4,67,8 };"
        }

        public void weightConvertToJSON()
        {
            JavaScriptSerializer jss1 = new JavaScriptSerializer();

            string weightString = jss1.Serialize(weight);
            string point = "var point=" + weightString + ";";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "point", point, true);

            string bodyFatString = jss1.Serialize(bodyfat);
            string point1 = "var point1=" + bodyFatString + ";";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "point1", point1, true);

        }
        protected void Populate_Activity_Chart()
        {
            var name = Session["User"];
            List<string> weekly_Activity_Division = new List<string>();
            try
            {

                using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    //var sql = "select top 7 * from Activity where Username = " + Session["User"].ToString() + " order by id DESC";
                    var sql = "Select Top 7 * from Activity Where [Username] = @Name Order By UpdatedDateTime ASC ";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    using (var dr = cmd.ExecuteReader())

                    {
                        while (dr.Read())
                        {
                            System.Diagnostics.Debug.WriteLine("CHART VALUES: "+(int)dr["Running"]);
                            weightLifting.Add((int)dr["WeightLifting"]);
                            running.Add((int)dr["Running"]);
                            walking.Add((int)dr["Walking"]);
                            other.Add((int)dr["Other"]);
        
                        }

                    }
                }
                activityConvertToJSON();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                
            }
        }
        protected void Populate_Weight_Chart()
        {
            var name = Session["User"];
            List<string> weekly_Weight = new List<string>();
            try
            {

                using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    //var sql = "select top 7 * from Activity where Username = " + Session["User"].ToString() + " order by id DESC";
                    var sql = "Select Top 7 * from Stats Where [Username] = @Name Order By UpdatedDateTime ASC ";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    using (var dr = cmd.ExecuteReader())

                    {
                        while (dr.Read())
                        {
                            //System.Diagnostics.Debug.WriteLine("CHART VALUES: " + (int)dr["Running"]);
                            weight.Add((int)dr["Weight"]);
                            bodyfat.Add((int)dr["BodyFat"]);
                           

                        }

                    }
                }
                weightConvertToJSON();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
        }
    }
}