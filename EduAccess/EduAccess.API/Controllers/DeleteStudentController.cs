using Microsoft.AspNetCore.Mvc;
using EduAccess.Application.Interfaces;

namespace EduAccess.API.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteStudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        public DeleteStudentController(IStudentRepository repository) => _repository = repository;

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}