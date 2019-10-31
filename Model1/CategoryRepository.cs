using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model1.Models;
using MySql.Data.MySqlClient;

namespace Model1
{
    public class CategoryRepository
    {
        private static string connectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<Category> GetCategories()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Categories";

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                var allCategories = new List<Category>();

                while (reader.Read() == true)
                {
                    var currentCategory = new Category();
                    currentCategory.CategoryID = reader.GetInt32("CategoryID");
                    currentCategory.Name = reader.GetString("Name");
                    allCategories.Add(currentCategory);
                }
                return allCategories;
            }
            
        }
    }
}
