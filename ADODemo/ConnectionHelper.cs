using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ADODemo
{
    public class ConnectionHelper
    {
        public static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                Console.WriteLine("state: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}", connection.ConnectionString);
            }

        }



        /// <summary>
        /// Requires Data Source (End Point)
        /// Initial Catalog (DB Name)
        /// Persist Security Info (always = true)
        /// User ID
        /// Password
        /// Encrypt = false
        /// </summary>
        /// <returns>Returns the full connection String</returns>
        private static string GetConnectionString()
        { 
            
            return "Data Source=demodatabase.clnb0ldm68iw.us-west-2.rds.amazonaws.com,1433;Initial Catalog=BearDB;Persist Security Info=True;User Id=master;Password=password;Encrypt=False;";
        }
    }
}
