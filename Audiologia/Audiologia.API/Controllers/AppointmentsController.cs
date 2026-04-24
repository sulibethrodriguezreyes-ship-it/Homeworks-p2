using Audiologia.Application.DTOs;
using Audiologia.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Audiologia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _service.GetByIdAsync(id);
            if (appointment is null) return NotFound();
            return Ok(appointment);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            return Ok(await _service.GetByPatientAsync(patientId));
        }

        [HttpGet("specialist/{specialistId}")]
        public async Task<IActionResult> GetBySpecialist(int specialistId)
        {
            return Ok(await _service.GetBySpecialistAsync(specialistId));
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            return Ok(await _service.GetByDateAsync(date));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppointmentCreateDto dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AppointmentUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}