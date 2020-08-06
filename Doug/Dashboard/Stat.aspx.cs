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
    public partial class Stat : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            {


            }
            else
            {

                DisplayStats();
            }
        }

        protected void btnStat_Click(object sender, EventArgs e)
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
                        SqlCommand statsGetLatest = new SqlCommand("Select Top 1 * from Stats Where [Username] = @Name Order by Id DESC", connection);
                        statsGetLatest.Parameters.AddWithValue("@Name", name);
                        using (var dr = statsGetLatest.ExecuteReader())
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
                            statement = "INSERT INTO Stats (Age, Height, Weight, BodyFat, Username, UpdatedDateTime) VALUES(@Age, @Height, @Weight, @BodyFat, @Name, @DateTime)";
                        }
                        else
                        {
                            // call udpate
                            statement = "UPDATE Stats SET [Age] = @Age, [Height] = @Height, [Weight] = @Weight, [BodyFat] = @BodyFat, [UpdatedDateTime] = @DateTime WHERE [Username] = @Name AND [Id] = @Id";
                        }
                        SqlCommand cmd = new SqlCommand(statement, connection);

                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Age", Age.Text);
                        cmd.Parameters.AddWithValue("@Height", Height.Text);
                        cmd.Parameters.AddWithValue("@Weight", Weight.Text);
                        cmd.Parameters.AddWithValue("@BodyFat", BodyFat.Text);
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
        protected void DisplayStats()
        {
            try
            {
                var name = Session["User"].ToString();
                using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    connection.Open();
                    var sql = "Select Top 1 * from Stats Where [Username] = @Name order by Id DESC ";
                    var cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    DateTime currentDateTime = System.DateTime.Now;
                    DateTime updatedDateTime = System.DateTime.Now;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();

                        updatedDateTime = (DateTime)dr["UpdatedDateTime"];
                        Age.Text = dr["Age"].ToString();
                        Height.Text = dr["Height"].ToString();

                        if (IsNextDay(currentDateTime, updatedDateTime))
                        {
                            connection.Close();
                        }
                        else
                        {
                            Weight.Text = dr["Weight"].ToString();
                            BodyFat.Text = dr["BodyFat"].ToString();

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
    }
}