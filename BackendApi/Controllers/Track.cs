using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tracks : ControllerBase
    {
        public CartingContext Context { get; }

        public Tracks(CartingContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Track> Tracks = Context.Tracks.ToList();
            return Ok(Tracks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Track? Track = Context.Tracks.Where(x => x.TrackId == id).FirstOrDefault();
            if (Track == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Track);
        }

        [HttpPost]
        public IActionResult Add(Track Track)
        {
            Context.Tracks.Add(Track);
            Context.SaveChanges();
            return Ok(Track);
        }

        [HttpPut]
        public IActionResult Update(Track Track)
        {
            Context.Tracks.Update(Track);
            Context.SaveChanges();
            return Ok(Track);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Track? Track = Context.Tracks.Where(x => x.TrackId == id).FirstOrDefault();
            if (Track == null)
            {
                return BadRequest("Not Found");
            }
            Context.Tracks.Remove(Track);
            Context.SaveChanges();
            return Ok();
        }
    }
}