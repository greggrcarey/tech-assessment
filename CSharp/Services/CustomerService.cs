using System.Collections.Generic;
using System.Linq;
using CSharp.Models;

namespace CSharp.Services
{
    public static class CustomerService
    {

        static List<Customer> Customers { get; }

        static CustomerService()
        {
            Customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "Ace Hardware"},
                new Customer{Id = 2, Name = "Home Depot"}
            };

        }

        public static Customer? Get(int id) => Customers.FirstOrDefault(c => c.Id == id);

    }

}