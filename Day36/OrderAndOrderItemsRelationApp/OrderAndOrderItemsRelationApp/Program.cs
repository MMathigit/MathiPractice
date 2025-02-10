using System.Collections.Generic;
using System.Security.Principal;
using System.Transactions;
using System;
using OrderAndOrderItemsRelationApp.Models;

namespace OrderAndOrderItemsRelationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(101, "Cust1", DateTime.Now);
            order1.AddItem(new OrderItem(1,"Book",10,10));
            order1.AddItem(new OrderItem(1, "Pen", 10, 3));
            order1.AddItem(new OrderItem(1, "Pencil", 5, 10));
            order1.AddItem(new OrderItem(1, "Note", 30, 5));


            PrintDetails(order1);

        }
        private static void PrintDetails(Order orderDetails)
        {

            Console.WriteLine($"Name is {orderDetails.CustomerName} Date is {orderDetails.OrderDate} and Total Order Qty is {orderDetails.TotalAmount}");

            List<OrderItem> orderItems = orderDetails.OrderItemDetails;

            foreach (OrderItem displayOrder in orderItems)
            {
                Console.WriteLine($"Type is :{displayOrder.ItemName}");
            }
        }
    }
}