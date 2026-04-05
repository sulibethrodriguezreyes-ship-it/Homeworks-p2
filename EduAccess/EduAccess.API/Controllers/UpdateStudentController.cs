using Microsoft.AspNetCore.Mvc;
using EduAccess.Application.Interfaces;
using EduAccess.Application.DTOs;

namespace EduAccess.API.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateStudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        public UpdateStudentController(IStudentRepository repository) => _repository = repository;

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentUpdateDto updateDto)
        {
            if (id != updateDto.StudentId) return BadRequest("El ID no coincide.");

            var student = await _repository.GetByIdAsync(id);
            if (student == null) return NotFound();

            student.FullName = updateDto.FullName;
            student.Community = updateDto.Community;
            student.HasInternet = updateDto.HasInternet;
            student.DeviceType = updateDto.DeviceType;

            await _repository.UpdateAsync(student);
            return NoContent();
        }
    }
}