using System.Collections.Generic;
using System.Linq;
using CSharp.Models;

namespace CSharp.Services
{
    public class CustomerService
    {

        private List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();

        }

        public Customer? Get(int id) => _customers.FirstOrDefault(c => c.Id == id);

    }

}