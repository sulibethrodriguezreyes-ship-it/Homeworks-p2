using Audiologia.Application.DTOs;

namespace Audiologia.Application.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponseDto>> GetAllAsync();
        Task<PatientResponseDto?> GetByIdAsync(int id);
        Task<PatientResponseDto> CreateAsync(PatientCreateDto dto);
        Task<PatientResponseDto?> UpdateAsync(int id, PatientUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PatientResponseDto>> SearchByNameAsync(string name);
        Task<PatientResponseDto?> GetByIdNumberAsync(string idNumber);
    }
}