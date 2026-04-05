using EduAccess.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EduAccess.Domain.Entities;

namespace EduAccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetStudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public GetStudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/GetStudents
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _repository.GetAllAsync();
            return Ok(students);
        }

        // --- ESTE ES EL QUE HACE QUE EL EDITAR FUNCIONE ---
        // GET: api/GetStudents/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null) return NotFound();

            return Ok(student);
        }
    }
}