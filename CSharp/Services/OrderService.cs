using System.Collections.Generic;
using System.Linq;
using CSharp.Models;
using CSharp.Interfaces;

namespace CSharp.Services
{

    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;

        static int nextId = 4;
        public OrderService()
        {
            _orders = new List<Order>();
        }
        public List<Order> GetAll() => _orders;
        public List<Order>? GetList(int id) => _orders.FindAll(o => o.Id == id);
        public Order? Get(int id) => _orders.FirstOrDefault(o => o.Id == id);
        public void Update(Order order)
        {
            var index = _orders.FindIndex(o => o.Id == order.Id);
            if (index == -1)
                return;

            _orders[index] = order;
        }

        public void Cancel(Order order)
        {
            var index = _orders.FindIndex(o => o.Id == order.Id);
            if (index == -1)
                return;

            _orders[index].IsActive = false;

        }
        public Order Create(Order order)
        {
            order.Id = nextId++;
            _orders.Add(order);

            return order;

        }

    }

}
