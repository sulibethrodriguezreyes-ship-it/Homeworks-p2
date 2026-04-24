using Audiologia.Application.DTOs;
using Audiologia.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Audiologia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HearingTestsController : ControllerBase
    {
        private readonly IHearingTestService _service;

        public HearingTestsController(IHearingTestService service)
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
            var test = await _service.GetByIdAsync(id);
            if (test is null) return NotFound();
            return Ok(test);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            return Ok(await _service.GetByPatientAsync(patientId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HearingTestCreateDto dto)
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
        public async Task<IActionResult> Update(int id, [FromBody] HearingTestUpdateDto dto)
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