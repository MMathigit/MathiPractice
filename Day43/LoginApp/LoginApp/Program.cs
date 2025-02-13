using Microsoft.Data.SqlClient;

namespace LoginApp
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            var connectionstring = "server=DESKTOP-7MAM3KF\\SQLEXPRESS;database=my_db;Integrated security = True;TrustServerCertificate=True";
            var con = new SqlConnection(connectionstring);

            Console.WriteLine("PLease enter the User ID:");
            var userid = Console.ReadLine();
            Console.WriteLine("PLease enter the Password:");
            var pwd = Console.ReadLine();
            con.Open();
            string check = "SElect * from Users WHERE uid =@User AND password = @pass";
            SqlCommand chksqlcmd = new SqlCommand(check, con);
            chksqlcmd.Parameters.AddWithValue("@User", userid);
            chksqlcmd.Parameters.AddWithValue("@pass", pwd);

            //Console.WriteLine(chksqlcmd.ExecuteScalar());
            int count = (int)chksqlcmd.ExecuteScalar();
            if (count == 0)
            {
                Console.WriteLine("User Not Found. Please Check...");
            }
            else { 
               
                var cmd = new SqlCommand("SElect * from Users WHERE uid =@User AND password = @pass", con);
                cmd.Parameters.AddWithValue("@User", userid);
                cmd.Parameters.AddWithValue("@pass", pwd);
                var reader = cmd.ExecuteReader(); //For select we have to use Reader
                                                  //Console.WriteLine(reader);
                while (reader.Read())
                {
                    Console.WriteLine($"The User Name is : {reader["firstname"]}{reader["lastname"]}");
                }
                con.Close();

            }
        }
    }
}