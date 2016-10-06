using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SOAPCAT
{
    public class DBHelper
    {
        private static string _connectionString = @"Data Source=students-server.database.windows.net;Initial Catalog=""Cat's"";Integrated Security=False;User ID=chri56a4;Password=K03g3bugt;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Get all cat's in database
        /// </summary>
        /// <returns></returns>
        public static List<Cat> GetAllCats()
        {
            string queryString = $"SELECT * FROM [Table]";
            var catList = new List<Cat>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(queryString, connection);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var c = new Cat();
                    c.Name = reader.GetString(1);
                    c.Age = reader.GetInt32(2);
                    c.UniqueIdentifier = reader.GetInt32(3);
                }
                connection.Close();
                return catList;
            }
            return null;
        }

        /// <summary>
        /// Get's all cats with a specific name
        /// takes a name (string) as parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Cat> GetCatByName(string name)
        {
            string queryString = $"SELECT * FROM [Table] WHERE Name = '{name}'";
            List<Cat> tobeReturnedList = new List<Cat>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(queryString, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cat c = new Cat();
                    c.Name = reader.GetString(1);
                    c.Age = reader.GetInt32(2);
                    c.UniqueIdentifier = reader.GetInt32(3);
                    tobeReturnedList.Add(c);
                }
                return tobeReturnedList;
            }
            return null;
        }

        /// <summary>
        /// Updates a cat in Database
        /// Takes Index(int32) and Cat(obj) as parameters
        /// </summary>
        /// <param name="index"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool UpdateCat(int index, Cat c)
        {
            string queryString =
    $"UPDATE * [Table] SET Name='{c.Name}', Age='{c.Age}', UniqueIdentifier='{c.UniqueIdentifier}'";
            if (DBCommand(queryString)) return true;
            return false;
        }

        /// <summary>
        /// Deletes a cat from the database.
        /// takes Cat(obj) as parameter
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool DeleteCat(Cat c)
        {
            string queryString =
                $"DELETE * FROM [Table] WHERE cpr='{c.UniqueIdentifier}'";

            if (DBCommand(queryString)) return true;
            return false;
        }

        /// <summary>
        /// Gets a cat from database.
        /// Takes Cat(obj) as parameter.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Cat GetCat(Cat c)
        {
            string queryString = $"SELECT * FROM [Table] WHERE cpr = '{c.UniqueIdentifier}'";
            var returnCat = new Cat();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(queryString, connection);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    returnCat.Name = reader.GetString(1);
                    returnCat.Age = reader.GetInt32(2);
                    returnCat.UniqueIdentifier = reader.GetInt32(3);
                }
                connection.Close();
                return returnCat;
            }
            return null;
        }

        /// <summary>
        /// Add's a cat to the database.
        /// Takes Cat(obj) as parameter.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool AddCat(Cat c)
        {
            string queryString =
                $"INSERT INTO [Table] values ('{c.Name}','{c.Age}','{c.UniqueIdentifier}')";
            if (DBCommand(queryString)) return true;
            return false;
        }

        /// <summary>
        /// Connects to the database, and gives it the query string.
        /// takes a string containing an SQL query as parameter.  
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private static bool DBCommand(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = queryString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                connection.Open();
                cmd.ExecuteReader();

                connection.Close();
                return true;
            }
        }
    }
}