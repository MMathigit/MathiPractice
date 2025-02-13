using MySql.Data.MySqlClient;
namespace MySqlApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
                {
                    var connectionString = "Server=127.0.0.1;Database=pr_mysqldb;User ID=root;Password=root;Pooling=true;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                    conn.Open();
                    var cmd = new MySqlCommand("SElect * from mysql_product", conn);
                    var reader = cmd.ExecuteReader(); //For select we have to use Reader
                    Console.WriteLine(reader);
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["name"]);
                        Console.WriteLine(reader["quantity"]);
                        Console.WriteLine(reader["price"]);

                    }
                conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }
        }
    }




           