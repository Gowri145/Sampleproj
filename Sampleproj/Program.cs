using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace StudentDataToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=student;Integrated Security=True";
            string query = "SELECT * FROM StudentInfo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();                                               

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    using (StreamWriter writedata = new StreamWriter("Student_Data.txt"))
                    {
                        writedata.WriteLine("ExternalStudentID, FirstName, LastName, DOB, SSN, Address, City, State, Email, MaritalStatus");

                        while (reader.Read())
                        {
                            writedata.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}",  
                                reader["ExternalStudentID"],
                                reader["FirstName"],               
                                reader["LastName"],        
                                reader["DOB"],      
                                reader["SSN"],           
                                reader["Adddress"],      
                                reader["City"],
                                reader["State"], 
                                reader["Email"],
                                reader["MaritalStatus"]);
                        }

                    }

                }
            }
        }
    }
}