using Microsoft.Ajax.Utilities;
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
    public partial class Diary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Page_Load");
            if (Page.IsPostBack)
            {

            }
            else
            {
                DisplayDiary();
                DisplayActivity();
            }
        }
        protected void DisplayDiary()
        {
            try
            {
                var name = Session["User"].ToString();
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    var sql = "Select * from Diary Where [Username] = @Name Order by id DESC";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    DateTime currentDateTime = System.DateTime.Now;
                    DateTime updatedDateTime = System.DateTime.Now;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();

                        updatedDateTime = (DateTime)dr["UpdatedDateTime"];

                        if (IsNextDay(currentDateTime, updatedDateTime))
                        {
                            connection.Close();
                        }
                        else
                        {
                            Calorie.Text = dr["Calorie"].ToString();
                            Breakfast.Text = dr["Breakfast"].ToString();
                            Lunch.Text = dr["Lunch"].ToString();
                            Dinner.Text = dr["Dinner"].ToString();
                            Snacks.Text = dr["Snacks"].ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        protected bool IsNextDay(DateTime currentDateTime, DateTime updatedDateTime)
        {
            return currentDateTime.Year >= updatedDateTime.Year &&
                currentDateTime.Month >= updatedDateTime.Month &&
                currentDateTime.Day > updatedDateTime.Day;
        }
        protected void DisplayActivity()
        {
            try
            {
                var name = Session["User"].ToString();
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    var sql = "Select * from Activity Where [Username] = @Name Order by id DESC";

                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    DateTime currentDateTime = System.DateTime.Now;
                    DateTime updatedDateTime = System.DateTime.Now;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();

                        updatedDateTime = (DateTime)dr["UpdatedDateTime"];

                        if (IsNextDay(currentDateTime, updatedDateTime))
                        {
                            connection.Close();
                        }
                        else
                        {
                            WeightLifting.Text = dr["WeightLifting"].ToString();
                            Running.Text = dr["Running"].ToString();
                            Walking.Text = dr["Walking"].ToString();
                            Other.Text = dr["Other"].ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        protected void btnDiary_Click(object sender, EventArgs e)
        {
            var name = Session["User"].ToString();
            {
                try
                {
                    using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                    {
                        connection.Open();
                        DateTime currentDateTime = System.DateTime.Now;
                        DateTime updatedDateTime = new DateTime();
                        int id = 0;
                        SqlCommand diaryGetLatest = new SqlCommand("Select Top 1 * from Diary Where [Username] = @Name Order by Id DESC", connection);
                        diaryGetLatest.Parameters.AddWithValue("@Name", name);
                        using (var dr = diaryGetLatest.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                {
                                    id = (int)dr["Id"];
                                    updatedDateTime = (DateTime)dr["UpdatedDateTime"];
                                }
                            }
                        }
                        DateTime nextDay = updatedDateTime.AddDays(1);
                        System.Diagnostics.Debug.WriteLine("######NEXT DAY: " + nextDay);
                        String statement = "";
                        if (currentDateTime.CompareTo(nextDay) > 0 || updatedDateTime == null)
                        {
                            // call insert
                            statement = "INSERT INTO Diary (Calorie, Breakfast, Lunch, Dinner, Snacks, Username, UpdatedDateTime) VALUES(@Calorie, @Breakfast, @Lunch, @Dinner, @Snacks, @Name, @DateTime)";
                        }
                        else
                        {
                            // call udpate
                            statement = "UPDATE Diary SET [Calorie] = @Calorie, [Breakfast] = @Breakfast, [Lunch] = @Lunch, [Dinner] = @Dinner, [Snacks] = @Snacks, [UpdatedDateTime] = @DateTime WHERE [Username] = @Name AND [Id] = @Id";
                        }
                        SqlCommand cmd = new SqlCommand(statement, connection);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Calorie", Calorie.Text);
                        cmd.Parameters.AddWithValue("@Breakfast", Breakfast.Text);
                        cmd.Parameters.AddWithValue("@Lunch", Lunch.Text);
                        cmd.Parameters.AddWithValue("@Dinner", Dinner.Text);
                        cmd.Parameters.AddWithValue("@Snacks", Snacks.Text);
                        cmd.Parameters.AddWithValue("@DateTime", System.DateTime.Now);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch
                {

                }
            }
        }
        protected void btnActivity_Click(object sender, EventArgs e)
        {
            var name = Session["User"].ToString();
            {
                try
                {
                    using (
                        var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                    {
                        connection.Open();
                        DateTime currentDateTime = System.DateTime.Now;
                        DateTime updatedDateTime = new DateTime();
                        int id = 0;
                        SqlCommand activityGetLatest = new SqlCommand("Select Top 1 * from Activity Where [Username] = @Name Order by Id DESC", connection);
                        activityGetLatest.Parameters.AddWithValue("@Name", name);
                        using (var dr = activityGetLatest.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                {
                                    id = (int)dr["Id"];
                                    updatedDateTime = (DateTime)dr["UpdatedDateTime"];
                                }
                            }
                        }
                        DateTime nextDay = updatedDateTime.AddDays(1);
                        System.Diagnostics.Debug.WriteLine("######NEXT DAY: " + nextDay);
                        String statement = "";
                        if (currentDateTime.CompareTo(nextDay) > 0 || updatedDateTime == null)
                        {
                            // call insert
                            statement = "INSERT INTO Activity (WeightLifting, Running, Walking, Other, Username, UpdatedDateTime) VALUES(@WeightLifting, @Running, @Walking, @Other, @Name, @DateTime)";
                        }
                        else
                        {
                            // call udpate
                            statement = "UPDATE Activity SET [WeightLifting] = @WeightLifting, [Running] = @Running, [Walking] = @Walking, [Other] = @Other, [UpdatedDateTime] = @DateTime WHERE [Username] = @Name AND [Id] = @Id";
                        }
                        SqlCommand cmd = new SqlCommand(statement, connection);

                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@WeightLifting", WeightLifting.Text);
                        cmd.Parameters.AddWithValue("@Running", Running.Text);
                        cmd.Parameters.AddWithValue("@Walking", Walking.Text);
                        cmd.Parameters.AddWithValue("@Other", Other.Text);
                        cmd.Parameters.AddWithValue("@DateTime", System.DateTime.Now);
                        cmd.Parameters.AddWithValue("@Id", id);


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



