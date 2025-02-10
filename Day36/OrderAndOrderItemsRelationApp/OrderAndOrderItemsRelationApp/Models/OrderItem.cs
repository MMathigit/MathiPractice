using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndOrderItemsRelationApp.Models
{
    public class OrderItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

       
        public OrderItem(int itemId, string itemName, int quantity, int price)
        {
            Price = price;
            ItemId = itemId;
            Quantity = quantity;
            ItemName = itemName;
        }
        /*public int itemId { 
            get { return ItemId; } 
        }
        public string itemName { get { return ItemName; } }

        public int quantity { get { return Quantity; } }

        public double price { get { return Price; } }*/
        public double TotalPrice
        {
            get { return Price * Quantity; }
        }
    }
}
