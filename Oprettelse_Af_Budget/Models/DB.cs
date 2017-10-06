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



        static public void AddTransaction(Container model)
        {   
            CreateConnection();

            string query = string.Format("INSERT INTO Transaction(Text, Value, Date, FK_CategoryID, FK_SubCategory) VALUES (@navn, @value, @date, @fk_categoryid, @fk_subcategory)");
            SqlCommand ImportData = new SqlCommand(query, connection);

            ImportData.Parameters.AddWithValue("@text", model.Text);
            ImportData.Parameters.AddWithValue("@value", model.Value);
            ImportData.Parameters.AddWithValue("@date", DateTime.Now.ToString());
            ImportData.Parameters.AddWithValue("@fk_categoryid", model.FK_CategoryID);
            ImportData.Parameters.AddWithValue("@fk_subcategory", model.FK_SubCategory);

            ImportData.ExecuteNonQuery();

            CloseConnection();
        }
    }
}