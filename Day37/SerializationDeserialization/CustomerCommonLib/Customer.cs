using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCommonLib
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Address> Addresses { get; private set; }

        public Customer()
        {
            Addresses = new List<Address> { };
        }


        public void AddAddress(Address address)
        {
           
            Addresses.Add(address);

        }
    }
}