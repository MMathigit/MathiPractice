using Microsoft.Data.SqlClient;

namespace ProductDatabaseConnection
{
    public class Program
    {
        static void Main(string[] args)
        {
            CaseStudy1();
            CaseStudy2();
        }
        private static void CaseStudy2()
        {
            var connectionstring = "server=DESKTOP-7MAM3KF\\SQLEXPRESS;database=my_db;Integrated security = True;TrustServerCertificate=True";
            var con = new SqlConnection(connectionstring);
            con.Open();
            var cmd = new SqlCommand("SElect * from product", con);
            var reader = cmd.ExecuteReader(); //For select we have to use Reader
            Console.WriteLine(reader);
            while (reader.Read()) {
                Console.WriteLine(reader["name"]);
                Console.WriteLine(reader["quantity"]);
                Console.WriteLine(reader["price"]);

            }
            con.Close();
        }
        private static void CaseStudy1()
        {
            var connectionstring = "server=DESKTOP-7MAM3KF\\SQLEXPRESS;database=my_db;Integrated security = True;TrustServerCertificate=True";
            var con = new SqlConnection(connectionstring);
            con.Open();
            Console.WriteLine("Connection opened connected to");
            Console.WriteLine(con.Database);
            Console.WriteLine("Connectio state is ");
            Console.WriteLine(con.State);
            con.Close();
            Console.WriteLine("Connectio state is ");
            Console.WriteLine(con.State);


        }

    }
}