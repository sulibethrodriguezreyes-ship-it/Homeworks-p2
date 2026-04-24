using Audiologia.Application.DTOs;

namespace Audiologia.Application.Services.Interfaces
{
    public interface ISpecialistService
    {
        Task<IEnumerable<SpecialistResponseDto>> GetAllAsync();
        Task<SpecialistResponseDto?> GetByIdAsync(int id);
        Task<SpecialistResponseDto> CreateAsync(SpecialistCreateDto dto);
        Task<SpecialistResponseDto?> UpdateAsync(int id, SpecialistUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<SpecialistResponseDto>> GetActiveAsync();
    }
}