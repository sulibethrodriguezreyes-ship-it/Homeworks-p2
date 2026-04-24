using Audiologia.Application.DTOs;
using Audiologia.Application.Interfaces;
using Audiologia.Application.Services.Interfaces;
using Audiologia.Domain.Entities;

namespace Audiologia.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;
        private readonly IPatientRepository _patientRepo;
        private readonly ISpecialistRepository _specialistRepo;

        public AppointmentService(
            IAppointmentRepository repo,
            IPatientRepository patientRepo,
            ISpecialistRepository specialistRepo)
        {
            _repo = repo;
            _patientRepo = patientRepo;
            _specialistRepo = specialistRepo;
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetAllAsync()
        {
            var appointments = await _repo.GetWithDetailsAsync();
            return appointments.Select(MapToResponse);
        }

        public async Task<AppointmentResponseDto?> GetByIdAsync(int id)
        {
            var appointment = await _repo.GetByIdWithDetailsAsync(id);
            return appointment is null ? null : MapToResponse(appointment);
        }

        public async Task<AppointmentResponseDto> CreateAsync(AppointmentCreateDto dto)
        {
            if (!await _patientRepo.ExistsAsync(dto.PatientId))
                throw new InvalidOperationException("The patient does not exist.");

            var specialist = await _specialistRepo.GetByIdAsync(dto.SpecialistId);
            if (specialist is null)
                throw new InvalidOperationException("The specialist does not exist.");

            if (!specialist.CanAttend())
                throw new InvalidOperationException("The specialist is not active.");

            var appointment = new Appointment(
                dto.ScheduledAt,
                dto.PatientId,
                dto.SpecialistId,
                dto.Reason,
                dto.AppointmentType,
                dto.Notes
            );

            var created = await _repo.AddAsync(appointment);
            var withDetails = await _repo.GetByIdWithDetailsAsync(created.Id);

            return MapToResponse(withDetails!);
        }

        public async Task<AppointmentResponseDto?> UpdateAsync(int id, AppointmentUpdateDto dto)
        {
            var appointment = await _repo.GetByIdAsync(id);
            if (appointment is null) return null;

            appointment.ScheduledAt = dto.ScheduledAt;
            appointment.Reason = dto.Reason;
            appointment.AppointmentType = dto.AppointmentType;
            appointment.ChangeStatus(dto.Status, dto.Notes);

            var updated = await _repo.UpdateAsync(appointment);
            var withDetails = await _repo.GetByIdWithDetailsAsync(updated.Id);

            return MapToResponse(withDetails!);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repo.ExistsAsync(id)) return false;
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetByPatientAsync(int patientId)
        {
            var appointments = await _repo.GetByPatientIdAsync(patientId);
            return appointments.Select(MapToResponse);
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetBySpecialistAsync(int specialistId)
        {
            var appointments = await _repo.GetBySpecialistIdAsync(specialistId);
            return appointments.Select(MapToResponse);
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetByDateAsync(DateTime date)
        {
            var appointments = await _repo.GetByDateAsync(date);
            return appointments.Select(MapToResponse);
        }

        private static AppointmentResponseDto MapToResponse(Appointment a)
        {
            return new AppointmentResponseDto
            {
                Id = a.Id,
                ScheduledAt = a.ScheduledAt,
                Status = a.Status.ToString(),
                Reason = a.Reason,
                AppointmentType = a.AppointmentType,
                Notes = a.Notes,
                PatientId = a.PatientId,
                PatientName = a.Patient?.GetFullName() ?? "",
                SpecialistId = a.SpecialistId,
                SpecialistName = a.Specialist?.GetFullName() ?? "",
                CreatedAt = a.CreatedAt
            };
        }
    }
}