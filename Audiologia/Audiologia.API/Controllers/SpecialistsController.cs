using Audiologia.Application.DTOs;
using Audiologia.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Audiologia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialistsController : ControllerBase
    {
        private readonly ISpecialistService _service;

        public SpecialistsController(ISpecialistService service)
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
            var specialist = await _service.GetByIdAsync(id);
            if (specialist is null) return NotFound();
            return Ok(specialist);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            return Ok(await _service.GetActiveAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SpecialistCreateDto dto)
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
        public async Task<IActionResult> Update(int id, [FromBody] SpecialistUpdateDto dto)
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