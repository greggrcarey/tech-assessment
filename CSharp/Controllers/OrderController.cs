using CSharp.Models;
using CSharp.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

/* 
Create order endpoint
--List all orders by customer endpoint
--Update order endpoint
--Cancel order endpoint
Tests to prove your code works as expected

*/
namespace CSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderService _orderService;
        private CustomerService _customerService;

        public OrderController()
        {
            _orderService = new OrderService();
            _customerService = new CustomerService();
        }

        [HttpGet("GetByCustomer/{id}")]
        public ActionResult<List<Order>> GetByCustomer(int id)
        {
            var customer = _customerService.Get(id);
            if (customer is null) return NotFound();

            var orders = _orderService.GetList(customer.Id);

            if (orders is null) return NotFound();
            else
            {
                return Ok(orders);
            }

        }

        [HttpPut("Cancel/{id}")]
        public IActionResult Cancel(int id)
        {
            var existingOrder = _orderService.Get(id);


            if (existingOrder is null) return BadRequest();
            if (existingOrder.Id != id) return BadRequest();

            _orderService.Cancel(existingOrder);

            return NoContent();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, Order order)
        {
            if (order.Id != id) return BadRequest();

            var existingOrder = _orderService.Get(id);

            if (existingOrder is null) return BadRequest();

            _orderService.Update(order);

            return NoContent();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            _orderService.Create(order);
            return CreatedAtAction(nameof(Create), new { id = order.Id }, order);
        }





    }

}