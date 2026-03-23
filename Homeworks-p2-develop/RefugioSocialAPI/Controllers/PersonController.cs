using Microsoft.AspNetCore.Mvc;
using RefugioSocialAPI.Data;
using RefugioSocialAPI.DTOs;
using RefugioSocialAPI.Entities;
using System.Reflection.Metadata;

namespace RefugioSocialAPI.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class PersonController : ControllerBase
    {
        private readonly RefugioSocialDbContext _context;

        public PersonController(RefugioSocialDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            var Persons = _context.Persons
                        .Select(x => new PersonsReadDTo
                        {
                            id = x.Id,
                            Name = x.Name,
                            Age = x.Age,
                            Identification = x.Identification,
                            RegistrationDate = x.RegistrationDate,
                        })
                        .ToList();
            return Ok(Persons);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Persons = _context.Persons.Find(id);

            if (Persons == null)
                return NotFound();

            var dto = new PersonsReadDTo
            {
                id = id,
                Name = Persons.Name,
                Age = Persons.Age,
                Identification = Persons.Identification,
                RegistrationDate = Persons.RegistrationDate,
            };

            return Ok(dto);

        }
        [HttpPost]
        public IActionResult Create(PersonsCreateDTo dto)
        {
            var person = new Person
            {
                Name = dto.Name,
                Age = dto.Age,
                Identification = dto.Identification,
                RegistrationDate = DateTime.Now,
            };
             
          

            _context.Persons.Add(person);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PersonsUpdateDTo UpdatePerson)
        {
            var person = _context.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            person.Name = UpdatePerson.Name;
            person.Age = UpdatePerson.Age;
            person.Identification = UpdatePerson.Identification;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
                return NotFound();

            _context.Persons.Remove(person);
            _context.SaveChanges();

            return NoContent();
        }

    }
}