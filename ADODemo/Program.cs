using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo
{
    class Program
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
        private static string GetQueryString()
        {
            return "Select Bears.[Name], [Type].TypeName,Cave.[Name] As [CaveName],Beehive.BeehiveID From Bears Inner Join[Type] On Bears.TypeId = [Type].TypeId Inner Join[BeeHive] On Bears.BeehiveID = Beehive.BeehiveID Inner Join[Cave] On Bears.CaveID = Cave.CaveID";
        }
        static void Main(string[] args)
        {
            string con = GetConnectionString();
            string query = GetQueryString();
            ConnectionHelper.OpenSqlConnection();
            ShowReadResult(con, query);
            Console.ReadLine();
        }

        public static void ShowReadResult(string connection, string query)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand(query,sqlcon);

                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //your code! write stuff to the console!!!
                        //look up MSDN docuentation for SQLDataReader
                        //print out a list of bears

                        //Prints out list of the bears names, types, caves and beehive numbers
                        // (type)reader[columnname]will get you the value in that column from whatever row the reader is at.
                        string bearname = (string)reader["Name"];
                        string typename = (string)reader["TypeName"];
                        string cavename = (string)reader["CaveName"];
                        string beehiveid = ""+ (int)reader["BeehiveID"];
                        Console.WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}", bearname,typename,cavename,beehiveid);

                    }
                    reader.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                Console.ReadLine();
            }
        }
    }

}
