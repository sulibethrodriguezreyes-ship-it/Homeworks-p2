using Audiologia.Application.DTOs;

namespace Audiologia.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResponseDto>> GetAllAsync();
        Task<AppointmentResponseDto?> GetByIdAsync(int id);
        Task<AppointmentResponseDto> CreateAsync(AppointmentCreateDto dto);
        Task<AppointmentResponseDto?> UpdateAsync(int id, AppointmentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AppointmentResponseDto>> GetByPatientAsync(int patientId);
        Task<IEnumerable<AppointmentResponseDto>> GetBySpecialistAsync(int specialistId);
        Task<IEnumerable<AppointmentResponseDto>> GetByDateAsync(DateTime date);
    }
}