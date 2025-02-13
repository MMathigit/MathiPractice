using MySql.Data.MySqlClient;

namespace TodoAppMysql
{
    public class Program
    {
       
        static string  connectionString = "Server=127.0.0.1;Database=pr_mysqldb;User ID=root;Password=root;Pooling=true;";
        static MySqlConnection conn = new MySqlConnection(connectionString);
        static void Main(string[] args)
        {    conn = new MySqlConnection(connectionString);

                int choice;
                Console.Clear();
                do
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Please Enter your Choice:");
                    Console.WriteLine("1.Insert Product");
                    Console.WriteLine("2.Update Product");
                    Console.WriteLine("3.Delete Product");
                    Console.WriteLine("4.Display the Product Details");
                    Console.WriteLine("5.Exit");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            InsertProduct();
                            break;
                        case 2:
                            UpdateProduct();
                            break;
                        case 3:
                            DeleteProduct();
                            break;
                        case 4:
                            SelectProduct();
                            break;
                        case 5:
                            Console.WriteLine("Exiting the application...");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice. Please enter the valid input");
                            break;
                    }
                } while (choice != 5);
                conn.Close();
            }
        
        private static void InsertProduct()
        {
            Console.WriteLine("INSERTING");
            Console.WriteLine("Please Enter the Product Name");
            string productName = Console.ReadLine();
            Console.WriteLine("Please Enter the Quantity");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Price");
            int price = int.Parse(Console.ReadLine());
            string query = "Insert into Mysql_Product(name,quantity,price)Values(@ProductName,@Quantity,@Price)";
            conn.Open();
            MySqlCommand sqlcmd = new MySqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@ProductName", productName);
            sqlcmd.Parameters.AddWithValue("@Quantity", quantity);
            sqlcmd.Parameters.AddWithValue("@Price", price);
            sqlcmd.ExecuteNonQuery();
            Console.WriteLine("Product Created Successfully");
            conn.Close();
        }
        private static void UpdateProduct()
        {
            Console.WriteLine("");
            Console.WriteLine("UPDATING");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please Enter the Product Name to be Updated");
            string productName = Console.ReadLine();
            string check = "SELECT Count(*) FROM Mysql_Product WHERE name = @ProductName";
            MySqlCommand chksqlcmd = new MySqlCommand(check, conn);
            chksqlcmd.Parameters.AddWithValue("@ProductName", productName);
            conn.Open();
            //Console.WriteLine(chksqlcmd.ExecuteScalar());
            int count = (int)chksqlcmd.ExecuteScalar();
            if (count == 0)
            {
                Console.WriteLine("Product Not Found. Please Check...");
            }
            else
            {
                Console.WriteLine("Please Enter the Quantity");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter the Price");
                int price = int.Parse(Console.ReadLine());
                string query = "Update Mysql_Product SET quantity = @Quantity,price = @Price WHERE name = @ProductName";

                MySqlCommand sqlcmd = new MySqlCommand(query, conn);
                sqlcmd.Parameters.AddWithValue("@ProductName", productName);
                sqlcmd.Parameters.AddWithValue("@Quantity", quantity);
                sqlcmd.Parameters.AddWithValue("@Price", price);
                sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Product Updated Successfully");
            }
            conn.Close();

        }
        private static void DeleteProduct()
        {
            Console.WriteLine("");
            Console.WriteLine("DELETING");
            Console.WriteLine("----------------");
            Console.WriteLine("");
            Console.WriteLine("PLease enter the Product to be deleted");
            var productName = Console.ReadLine();
            conn.Open();
            string check = "SELECT Count(*) FROM Mysql_Product WHERE name = @ProductName";
            MySqlCommand chksqlcmd = new MySqlCommand(check, conn);
            chksqlcmd.Parameters.AddWithValue("@ProductName", productName);

            //Console.WriteLine(chksqlcmd.ExecuteScalar());
            int count = (int)chksqlcmd.ExecuteScalar();
            if (count == 0)
            {
                Console.WriteLine("Product Not Found. Please Check...");
            }
            else
            {
                string query = "DELETE FROM Mysql_Product WHERE NAME = @ProductName";

                MySqlCommand sqlcmd = new MySqlCommand(query, conn);
                sqlcmd.Parameters.AddWithValue("@ProductName", productName);
                sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Product Deleted Successfully");
            }
            conn.Close();
        }
        private static void SelectProduct()
        {
            conn.Open();
            var cmd = new MySqlCommand("SElect * from Mysql_Product", conn);

            var reader = cmd.ExecuteReader(); //For select we have to use Reader
            //Console.WriteLine(reader);
            while (reader.Read())
            {
                Console.WriteLine($"Name: {reader["name"]}; Quantity: {reader["quantity"]}; Price: {reader["price"]}");
            }
            conn.Close();
        }
    }
}