using CustomerLocationApp.Models;

namespace CustomerLocationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Customer> customers = new List<Customer>
        {
            new Customer("Mathi", "Chennai"),
            new Customer("Cust2", "Trichy"),
            new Customer("Cust3", "Chennai"),
            new Customer("Cust4", "Madurai"),
            new Customer("Cust5", "Jaipur"),
            new Customer("Cust6", "Madurai")
        };

            Dictionary<string, int> locationCount = GetCustomerCountByLocation(customers);

            
            Console.WriteLine("Number of customers in each location:");
            foreach (var location in locationCount)
            {
                Console.WriteLine($"{location.Key}: {location.Value} customers");
            }
        }
              
        static Dictionary<string, int> GetCustomerCountByLocation(List<Customer> customers)
        {
            Dictionary<string, int> locationCount = new Dictionary<string, int>();
            
            foreach (var customer in customers)
            {
                if (locationCount.ContainsKey(customer.Location))
                {
                    locationCount[customer.Location]+=1;
                }
                else
                {
                    locationCount[customer.Location] = 1;
                }
            }

            return locationCount; 
        }
    }
}