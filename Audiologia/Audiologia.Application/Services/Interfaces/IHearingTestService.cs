using Audiologia.Application.DTOs;

namespace Audiologia.Application.Services.Interfaces
{
    public interface IHearingTestService
    {
        Task<IEnumerable<HearingTestResponseDto>> GetAllAsync();
        Task<HearingTestResponseDto?> GetByIdAsync(int id);
        Task<HearingTestResponseDto> CreateAsync(HearingTestCreateDto dto);
        Task<HearingTestResponseDto?> UpdateAsync(int id, HearingTestUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<HearingTestResponseDto>> GetByPatientAsync(int patientId);
    }
}