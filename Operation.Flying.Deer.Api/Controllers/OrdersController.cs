using Microsoft.AspNetCore.Mvc;
using Operation.Flying.Deer.Domain.Orders;
using Operation.Flying.Deer.Data;
using Microsoft.EntityFrameworkCore;

namespace Operation.Flying.Deer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly StoreContext _db;

        public OrdersController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_db.Orders);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetOrder(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        
        [HttpPost]
        public IActionResult Post(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Created($"/orders/{order.Id}", order);
        }
        
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            
            if (_db.Orders.Find(id) == null)
            {
                return NotFound();
            }
            
            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();
            
            return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            
            _db.Orders.Remove(order);
            _db.SaveChanges();
            
            return Ok();
        }
    }
}