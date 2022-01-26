using System.Collections.Generic;
using System.Linq;
using CSharp.Models;

namespace CSharp.Services
{

    public static class OrderService
    {
        static List<Order> Orders { get; }
        static int nextId = 4;

        static OrderService()
        {
            Orders = new List<Order>
            {
                new Order{ Id = 1, Description = "Widget 1", IsActive = true, CustomerId = 1},
                new Order{ Id = 2, Description = "Whirly Gig 1", IsActive = true, CustomerId = 1},
                new Order{ Id = 3, Description = "Doo Dad 1", IsActive = true, CustomerId = 2}
            };

        }

        /*
        Create order endpoint
        --List all orders by customer endpoint
        --Update order endpoint
        --Cancel order endpoint
        Tests to prove your code works as expected
        
        */

        public static List<Order> GetAll() => Orders;

        public static List<Order>? GetList(int id) => Orders.FindAll(o => o.Id == id);

        public static Order? Get(int id) => Orders.FirstOrDefault(o => o.Id == id);


        public static void Update(Order order)
        {
            var index = Orders.FindIndex(o => o.Id == order.Id);
            if (index == -1)
                return;

            Orders[index] = order;
        }

        public static void Cancel(Order order)
        {
            var index = Orders.FindIndex(o => o.Id == order.Id);
            if (index == -1)
                return;

            Orders[index].IsActive = false;

        }

        public static List<Order>? GetOrderByCustomerId(int id)
        {
            var selectedCustomer = CustomerService.Get(id);

            if (selectedCustomer is null) return null;

            return GetList(selectedCustomer.Id);

        }

        public static Order Create(Order order)
        {
            order.Id = nextId++;
            var orders = GetAll();
            orders.Add(order);

            return order;

        }

    }

}
