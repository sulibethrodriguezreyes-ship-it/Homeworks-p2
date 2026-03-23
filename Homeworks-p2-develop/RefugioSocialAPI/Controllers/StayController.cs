

using global::RefugioSocialAPI.Data;
using global::RefugioSocialAPI.DTOs;
using global::RefugioSocialAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RefugioSocialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StaysController : ControllerBase
    {
        private readonly RefugioSocialDbContext _context;

        public StaysController(RefugioSocialDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var stays = _context.Stays
                        .Select(x => new StaysReadDTo
                        {
                            Id = x.Id,
                            CheckInDate = x.CheckInDate,
                            CheckOutDate = x.CheckOutDate,
                            PersonId = x.PersonId,
                        })
                        .ToList();

            return Ok(stays);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var stay = _context.Stays.Find(id);

            if (stay == null)
                return NotFound();

            var dto = new StaysReadDTo
            {
                Id = stay.Id,
                CheckInDate = stay.CheckInDate,
                CheckOutDate = stay.CheckOutDate,
                PersonId = stay.PersonId,
            };

            return Ok(dto);
        }


        [HttpPost]
        public IActionResult Create(StaysCreateDTo dto)
        {
            var stay = new Stay
            {
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                PersonId = dto.PersonId,
            };

            _context.Stays.Add(stay);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = stay.Id }, stay);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, StaysUpdateDTo updateStay)
        {
            var stay = _context.Stays.Find(id);

            if (stay == null)
                return NotFound();

            stay.CheckInDate = updateStay.CheckInDate;
            stay.CheckOutDate = updateStay.CheckOutDate;

            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var stay = _context.Stays.Find(id);

            if (stay == null)
                return NotFound();

            _context.Stays.Remove(stay);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
