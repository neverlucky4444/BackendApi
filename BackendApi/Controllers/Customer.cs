using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers : ControllerBase
    {
        public CartingContext Context { get; }

        public Customers(CartingContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Customer> Customers = Context.Customers.ToList();
            return Ok(Customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Customer? Customer = Context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            if (Customer == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Customer);
        }

        [HttpPost]
        public IActionResult Add(Customer Customer)
        {
            Context.Customers.Add(Customer);
            Context.SaveChanges();
            return Ok(Customer);
        }

        [HttpPut]
        public IActionResult Update(Customer Customer)
        {
            Context.Customers.Update(Customer);
            Context.SaveChanges();
            return Ok(Customer);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Customer? Customer = Context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            if (Customer == null)
            {
                return BadRequest("Not Found");
            }
            Context.Customers.Remove(Customer);
            Context.SaveChanges();
            return Ok();
        }
    }
}