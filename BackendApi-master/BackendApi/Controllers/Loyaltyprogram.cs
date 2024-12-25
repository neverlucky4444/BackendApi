using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loyaltyprograms : ControllerBase
    {
        public CartingContext Context { get; }

        public Loyaltyprograms(CartingContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Loyaltyprogram> Loyaltyprograms = Context.Loyaltyprograms.ToList();
            return Ok(Loyaltyprograms);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Loyaltyprogram? Loyaltyprogram = Context.Loyaltyprograms.Where(x => x.LoyaltyId == id).FirstOrDefault();
            if (Loyaltyprogram == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Loyaltyprogram);
        }

        [HttpPost]
        public IActionResult Add(Loyaltyprogram Loyaltyprogram)
        {
            Context.Loyaltyprograms.Add(Loyaltyprogram);
            Context.SaveChanges();
            return Ok(Loyaltyprogram);
        }

        [HttpPut]
        public IActionResult Update(Loyaltyprogram Loyaltyprogram)
        {
            Context.Loyaltyprograms.Update(Loyaltyprogram);
            Context.SaveChanges();
            return Ok(Loyaltyprogram);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Loyaltyprogram? Loyaltyprogram = Context.Loyaltyprograms.Where(x => x.LoyaltyId == id).FirstOrDefault();
            if (Loyaltyprogram == null)
            {
                return BadRequest("Not Found");
            }
            Context.Loyaltyprograms.Remove(Loyaltyprogram);
            Context.SaveChanges();
            return Ok();
        }
    }
}