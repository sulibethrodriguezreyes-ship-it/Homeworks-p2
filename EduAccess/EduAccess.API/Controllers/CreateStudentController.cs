using EduAccess.Application.Interfaces;
using EduAccess.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduAccess.API.Controllers
{
    [Route("api/[controller]")] // La ruta será: api/CreateStudent
    [ApiController]
    public class CreateStudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public CreateStudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            if (student == null) return BadRequest("Datos del estudiante vacíos.");

            await _repository.CreateAsync(student);
            return Ok(student); // Ahora devuelve el objeto creado correctamente
        }
    }
}