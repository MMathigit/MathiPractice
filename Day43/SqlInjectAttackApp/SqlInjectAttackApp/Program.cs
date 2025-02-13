using Microsoft.Data.SqlClient;

namespace SqlInjectAttackApp
{
    public class Program
    {
 
        static void Main(string[] args)
        {
            var connectionstring = "server=DESKTOP-7MAM3KF\\SQLEXPRESS;database=my_db;Integrated security = True;TrustServerCertificate=True";
            var con = new SqlConnection(connectionstring);
            Console.WriteLine("Enter the product id: ");
            var productName = Console.ReadLine();
            
            var cmd = new SqlCommand("SElect * from product WHERE name = @Product", con);
            cmd.Parameters.AddWithValue("@Product", productName);
            con.Open();
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