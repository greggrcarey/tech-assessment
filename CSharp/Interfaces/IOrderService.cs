using CSharp.Services;
using CSharp.Models;
using System.Collections.Generic;

namespace CSharp.Interfaces
{
    public interface IOrderService
    {
        void Cancel(Order order);
        Order Create(Order order);
        Order? Get(int id);
        List<Order> GetAll();
        List<Order>? GetList(int id);
        void Update(Order order);
    }
}