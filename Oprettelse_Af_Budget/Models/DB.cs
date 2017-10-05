using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Oprettelse_Af_Budget.Models
{
    public class DB
    {
        private static SqlConnection connection = null;

        // forbinder til databasen via en connection string i App.Config
        static public void CreateConnection()
        {
            try
            {
                if (connection == null)
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["post"].ConnectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        // lukker forbindelsen til databasen
        static public void CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }



        static public void AddBudget()
        {   
            CreateConnection();

            string query = string.Format("INSERT INTO Transaction(Text, Value, Date, FK_CategoryID, FK_SubCategory) VALUES (@navn, @value, @date, @fk_categoryid, @fk_subcategory)");
            SqlCommand ImportData = new SqlCommand(query, connection);

            //ImportData.Parameters.AddWithValue("@text", budget.Text);
            //ImportData.Parameters.AddWithValue("@value", budget.Value);
            //ImportData.Parameters.AddWithValue("@date", DateTime.Now.ToString());
            //ImportData.Parameters.AddWithValue("@fk_categoryid", budget.FK_CategoryID);
            //ImportData.Parameters.AddWithValue("@fk_subcategory", budget.FK_SubCategory);

            ImportData.ExecuteNonQuery();

            CloseConnection();
        }
    }
}