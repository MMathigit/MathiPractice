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

            Dictionary<string, List<Customer>> groupedByLocation = GroupCustomersByLocation(customers);

            Console.WriteLine("Customers grouped by location:");
            foreach (var group in groupedByLocation)
            {
                Console.WriteLine($"\nLocation: {group.Key}");
                foreach (var customer in group.Value)
                {
                    Console.WriteLine($"{customer.Name}");
                }
            }
        }

        static Dictionary<string, List<Customer>> GroupCustomersByLocation(List<Customer> customers)
        {
            Dictionary<string, List<Customer>> locationGroups = new Dictionary<string, List<Customer>>();

           
            foreach (var customer in customers)
            {
                if (locationGroups.ContainsKey(customer.Location))
                {
                    locationGroups[customer.Location].Add(customer);  
                }
                else
                {
                    locationGroups[customer.Location] = new List<Customer> { customer };  
                }
            }

            return locationGroups;
        }
    }
}