using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FinanceSpendAnalysisFramework.PageObjects
{
    public class DatabaseUtil
    {
        SqlConnection con;
        public bool DatabaseConnectionStatus(string serverName, string databaseName, string userName, string password)
        {
            try
            {
                var connetionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userName};Password={password}";
                con = new SqlConnection(connetionString);
                con.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void CreateDatabase()
        {
            string sqlCommand = "Create Database PaymentsInfo;";
            SqlCommand sql = new SqlCommand("Create Database PaymentsInfo;", con);
            sql.ExecuteNonQuery();
        }
    }
}
