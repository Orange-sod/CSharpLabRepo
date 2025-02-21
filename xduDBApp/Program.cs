using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.SqlClient {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("it runs");
            // Create the connection to the resource!
            // This is the connection, that is established and // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection()) {
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows
                // Authentication
                conn.ConnectionString = "Server = 127.0.0.1; Database = users; User Id = christoph; Password = Aa33445566;";
                conn.Open();
                // Create the command
                // SqlCommand command = new SqlCommand("SELECT * FROM MyTable
                // WHERE UserId = @0", conn);
                SqlCommand command = new SqlCommand("SELECT * FROM xduTable", conn);
                int max = 0;
                using (SqlDataReader reader = command.ExecuteReader()) {
                    Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    while (reader.Read()) {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2}",
                            reader[0], reader[1], reader[2]));
                        max = Convert.ToInt32(reader[0].ToString()); //yk
                    }
                }

                Console.WriteLine("Data displayed! Now press enter to move to the next");
                Console.WriteLine("Max ID is" + max); //yk
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("INSERT INTO command");
                // Create the command, to insert the data into the Table!
                // this is a simple INSERT INTO command!
                SqlCommand insertCommand =
                    new SqlCommand("INSERT INTO xduTable (UserId,UserName, UserEmail) VALUES (@0, @1, @2)", conn);

                // In the command, there are some parameters denoted by @, you can
                // change their value on a condition, in my code they're hardcoded.
                insertCommand.Parameters.Add(new SqlParameter("0", (max + 1))); //yk
                insertCommand.Parameters.Add(new SqlParameter("1", "Test Column"));
                insertCommand.Parameters.Add(new SqlParameter("2", "Test Column"));
                // insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
                //insertCommand.Parameters.Add(new SqlParameter("3", false));
                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                Console.WriteLine("Done! Press enter to move to the next step");
                Console.ReadLine();
                Console.Clear();
                try {
                    // Create the command to execute! With the wrong name of the table
                    // (Depends on your Database tables)
                    //conn);
                    SqlCommand errorCommand = new SqlCommand("SELECT * FROM xduTable", conn);
                    // Execute the command, here the error will pop up!
                    // But since we're catching the code block's errors, it will be
                    // displayed inside the console.
                    errorCommand.ExecuteNonQuery();
                }
                // catch block
                catch (SqlException er) {
                    // Since there is no such column as someErrorColumn (Depends on your
                    // SQL Server will throw an error.
                    Console.WriteLine("There was an error reported by SQL Server, " +
                                      er.Message);
                }
            }

            Console.ReadLine();
        }
    }
}