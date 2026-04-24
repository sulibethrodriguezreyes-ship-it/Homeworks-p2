using Audiologia.Application.DTOs;
using Audiologia.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Audiologia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _service.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            if (patient is null) return NotFound($"Patient with Id {id} not found.");
            return Ok(patient);
        }

        [HttpGet("idnumber/{idNumber}")]
        public async Task<IActionResult> GetByIdNumber(string idNumber)
        {
            var patient = await _service.GetByIdNumberAsync(idNumber);
            if (patient is null) return NotFound($"Patient with ID number {idNumber} not found.");
            return Ok(patient);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            var patients = await _service.SearchByNameAsync(name);
            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientCreateDto dto)
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
        public async Task<IActionResult> Update(int id, [FromBody] PatientUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated is null) return NotFound($"Patient with Id {id} not found.");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound($"Patient with Id {id} not found.");
            return NoContent();
        }
    }
}