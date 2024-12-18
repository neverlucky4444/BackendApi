using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sales : ControllerBase
    {
        public CartingContext Context { get; }

        public Sales(CartingContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Sale> Sales = Context.Sales.ToList();
            return Ok(Sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Sale? Sale = Context.Sales.Where(x => x.SaleId == id).FirstOrDefault();
            if (Sale == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Sale);
        }

        [HttpPost]
        public IActionResult Add(Sale Sale)
        {
            Context.Sales.Add(Sale);
            Context.SaveChanges();
            return Ok(Sale);
        }

        [HttpPut]
        public IActionResult Update(Sale Sale)
        {
            Context.Sales.Update(Sale);
            Context.SaveChanges();
            return Ok(Sale);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Sale? Sale = Context.Sales.Where(x => x.SaleId == id).FirstOrDefault();
            if (Sale == null)
            {
                return BadRequest("Not Found");
            }
            Context.Sales.Remove(Sale);
            Context.SaveChanges();
            return Ok();
        }
    }
}