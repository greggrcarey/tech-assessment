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
        public OrderController() { }

        [HttpGet("GetByCustomer/{id}")]
        public ActionResult<List<Order>> GetByCustomer(int id)
        {
            var orders = OrderService.GetOrderByCustomerId(id);

            if (orders is null) return NotFound();
            else
            {
                return Ok(orders);
            }

        }

        [HttpPut("Cancel/{id}")]
        public IActionResult Cancel(int id)
        {
            var existingOrder = OrderService.Get(id);


            if (existingOrder is null) return BadRequest();
            if (existingOrder.Id != id) return BadRequest();

            OrderService.Cancel(existingOrder);

            return NoContent();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, Order order)
        {
            if (order.Id != id) return BadRequest();

            var existingOrder = OrderService.Get(id);

            if (existingOrder is null) return BadRequest();

            OrderService.Update(order);

            return NoContent();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            OrderService.Create(order);
            return CreatedAtAction(nameof(Create), new { id = order.Id }, order);
        }





    }

}