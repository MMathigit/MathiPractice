﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLocationApp.Models
{
    
    class Customer
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public Customer(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
