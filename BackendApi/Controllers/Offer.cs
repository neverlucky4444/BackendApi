using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Offers : ControllerBase
    {
        public CartingContext Context { get; }

        public Offers(CartingContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Offer> Offers = Context.Offers.ToList();
            return Ok(Offers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Offer? Offer = Context.Offers.Where(x => x.OfferId == id).FirstOrDefault();
            if (Offer == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Offer);
        }

        [HttpPost]
        public IActionResult Add(Offer Offer)
        {
            Context.Offers.Add(Offer);
            Context.SaveChanges();
            return Ok(Offer);
        }

        [HttpPut]
        public IActionResult Update(Offer Offer)
        {
            Context.Offers.Update(Offer);
            Context.SaveChanges();
            return Ok(Offer);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Offer? Offer = Context.Offers.Where(x => x.OfferId == id).FirstOrDefault();
            if (Offer == null)
            {
                return BadRequest("Not Found");
            }
            Context.Offers.Remove(Offer);
            Context.SaveChanges();
            return Ok();
        }
    }
}