using Model1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model1
{
    public class DepartmentsRepository
    {
        private static string connectionString = "Server=localhost;Database=bestbuy;uid=root;PWD=pasword";

        public List<Departments> GetAllDepartments()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Departments;";

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Departments> allDepartments = new List<Departments>();

                while (reader.Read() == true)
                {
                    var DEP = new Departments();
                    DEP.ID = reader.GetInt32("DepartmentID");
                    DEP.Name = reader.GetString("Name");
                    

                    allDepartments.Add(DEP);


                }
                return allDepartments;
            }
        }

        
        
            public List<Departments> ViewDepartment(int id)
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Departments WHERE DepartmentID = @id;";
                cmd.Parameters.AddWithValue("id", id);

                using (conn)
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<Departments> allDepartments = new List<Departments>();

                    while (reader.Read() == true)
                    {
                        var DEP = new Departments();
                        DEP.ID = reader.GetInt32("DepartmentID");
                        DEP.Name = reader.GetString("Name");


                        allDepartments.Add(DEP);


                    }
                    return allDepartments;
                }
            }
        }
    }

