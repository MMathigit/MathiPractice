using Microsoft.Data.SqlClient;

namespace CRUDAndToDoApp
{
    public class Program
    {
        static string connectionstring = "server=DESKTOP-7MAM3KF\\SQLEXPRESS;database=my_db;Integrated security = True;TrustServerCertificate=True";
        static SqlConnection con;
        static void Main(string[] args)
        {
            con = new SqlConnection(connectionstring);
            
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
            con.Close();
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
            string query = "Insert into Product(name,quantity,price)Values(@ProductName,@Quantity,@Price)";
            con.Open();
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.Parameters.AddWithValue("@ProductName", productName);
            sqlcmd.Parameters.AddWithValue("@Quantity", quantity);
            sqlcmd.Parameters.AddWithValue("@Price", price);
            sqlcmd.ExecuteNonQuery();
            Console.WriteLine("Employee Created Successfully");
            con.Close();
        }
        private static void UpdateProduct()
        {
            Console.WriteLine("");
            Console.WriteLine("UPDATING");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please Enter the Product Name to be Updated");
            string productName = Console.ReadLine();
            string check = "SELECT Count(*) FROM PRODUCT WHERE name = @ProductName";
            SqlCommand chksqlcmd = new SqlCommand(check, con);
            chksqlcmd.Parameters.AddWithValue("@ProductName", productName);
            con.Open();
            //Console.WriteLine(chksqlcmd.ExecuteScalar());
            int count = (int)chksqlcmd.ExecuteScalar();  
            if (count == 0)
            {
                Console.WriteLine("Product Not Found. Please Check...");
            }
            else {
                Console.WriteLine("Please Enter the Quantity");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter the Price");
                int price = int.Parse(Console.ReadLine());
                string query = "Update Product SET quantity = @Quantity,price = @Price WHERE name = @ProductName";
                
                SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.Parameters.AddWithValue("@ProductName", productName);
            sqlcmd.Parameters.AddWithValue("@Quantity", quantity);
            sqlcmd.Parameters.AddWithValue("@Price", price);
            sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Employee Updated Successfully");
            }
            con.Close();
           
        }
        private static void DeleteProduct()
        {
            Console.WriteLine("");
            Console.WriteLine("DELETING");
            Console.WriteLine("----------------");
            Console.WriteLine("");
            Console.WriteLine("PLease enter the Product to be deleted");
            var productName = Console.ReadLine();
            con.Open();
            string check = "SELECT Count(*) FROM PRODUCT WHERE name = @ProductName";
            SqlCommand chksqlcmd = new SqlCommand(check, con);
            chksqlcmd.Parameters.AddWithValue("@ProductName", productName);

            //Console.WriteLine(chksqlcmd.ExecuteScalar());
            int count = (int)chksqlcmd.ExecuteScalar();
                if (count == 0) {
                Console.WriteLine("Product Not Found. Please Check...");
            }
            else { 
            string query = "DELETE FROM PRODUCT WHERE NAME = @ProductName";
            
          SqlCommand sqlcmd = new SqlCommand(query,con);
            sqlcmd.Parameters.AddWithValue("@ProductName",productName);
            sqlcmd.ExecuteNonQuery();
            Console.WriteLine("Product Deleted Successfully");
            }
            con.Close();
        }
        private static void SelectProduct()
        {
            con.Open();
            var cmd = new SqlCommand("SElect * from product", con);
            
            var reader = cmd.ExecuteReader(); //For select we have to use Reader
            //Console.WriteLine(reader);
            while (reader.Read())
            {
                Console.WriteLine($"Name: {reader["name"]}; Quantity: {reader["quantity"]}; Price: {reader["price"]}");
            }
            con.Close();    
        }
    }
}