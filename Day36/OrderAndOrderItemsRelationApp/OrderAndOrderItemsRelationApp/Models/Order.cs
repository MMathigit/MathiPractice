using System;
using System.Collections.Generic;
using System.Transactions;

namespace OrderAndOrderItemsRelationApp.Models
{
    public class Order
    {
        private readonly int _orderId;
        private readonly string _customerName;
        private readonly DateTime _orderDate;
        private List<OrderItem> _orderItems = new List<OrderItem>();  

        public Order(int orderId, string customerName, DateTime orderDate)
        {
            _orderId = orderId;
            _customerName = customerName;
            _orderDate = orderDate;
        }

        public void AddItem(OrderItem item)
        {
            _orderItems.Add(item);  // Add the item to the list
            Console.WriteLine("Item added to order.");
        }
        public List<OrderItem> OrderItemDetails
        {

            get
            {
                return _orderItems;
            }
        }
        public double TotalAmount
        {
            get
            {
                double total = 0;
                foreach (var item in _orderItems)
                {
                    total += item.TotalPrice;
                }
                return total;
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
        }

        //public int OrderId
        //{
        //    get { return _orderId; }
        //}
    }
}
