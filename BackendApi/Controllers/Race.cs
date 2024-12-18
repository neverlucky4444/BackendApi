using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Races : ControllerBase
    {
        public CartingContext Context { get; }

        public Races(CartingContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Race> Races = Context.Races.ToList();
            return Ok(Races);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Race? Race = Context.Races.Where(x => x.RaceId == id).FirstOrDefault();
            if (Race == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Race);
        }

        [HttpPost]
        public IActionResult Add(Race Race)
        {
            Context.Races.Add(Race);
            Context.SaveChanges();
            return Ok(Race);
        }

        [HttpPut]
        public IActionResult Update(Race Race)
        {
            Context.Races.Update(Race);
            Context.SaveChanges();
            return Ok(Race);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Race? Race = Context.Races.Where(x => x.RaceId == id).FirstOrDefault();
            if (Race == null)
            {
                return BadRequest("Not Found");
            }
            Context.Races.Remove(Race);
            Context.SaveChanges();
            return Ok();
        }
    }
}