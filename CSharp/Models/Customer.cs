using System.Collections;
using System.Collections.Generic;

namespace CSharp.Models
{

    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Order>? Order { get; set; }
    }
}