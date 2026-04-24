using Audiologia.Application.DTOs;
using Audiologia.Application.Interfaces;
using Audiologia.Application.Services.Interfaces;
using Audiologia.Domain.Entities;

namespace Audiologia.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<PatientResponseDto>> GetAllAsync()
        {
            var patients = await _repo.GetAllWithDetailsAsync();
            return patients.Select(MapToResponse);
        }

        public async Task<PatientResponseDto?> GetByIdAsync(int id)
        {
            var patient = await _repo.GetByIdWithDetailsAsync(id);
            return patient is null ? null : MapToResponse(patient);
        }

        public async Task<PatientResponseDto> CreateAsync(PatientCreateDto dto)
        {
            var existing = await _repo.GetByIdNumberAsync(dto.IdNumber);
            if (existing is not null)
                throw new InvalidOperationException($"A patient with ID number {dto.IdNumber} already exists.");

            var patient = new Patient(
                dto.FirstName,
                dto.LastName,
                dto.IdNumber,
                dto.DateOfBirth,
                dto.Phone,
                dto.Email,
                dto.Address
            );

            patient.MedicalHistory = dto.MedicalHistory;

            var created = await _repo.AddAsync(patient);
            return MapToResponse(created);
        }

        public async Task<PatientResponseDto?> UpdateAsync(int id, PatientUpdateDto dto)
        {
            var patient = await _repo.GetByIdAsync(id);
            if (patient is null) return null;

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.Phone = dto.Phone;
            patient.Email = dto.Email;
            patient.Address = dto.Address;
            patient.MedicalHistory = dto.MedicalHistory;

            var updated = await _repo.UpdateAsync(patient);
            return MapToResponse(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repo.ExistsAsync(id)) return false;
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<PatientResponseDto>> SearchByNameAsync(string name)
        {
            var patients = await _repo.SearchByNameAsync(name);
            return patients.Select(MapToResponse);
        }

        public async Task<PatientResponseDto?> GetByIdNumberAsync(string idNumber)
        {
            var patient = await _repo.GetByIdNumberAsync(idNumber);
            return patient is null ? null : MapToResponse(patient);
        }

        private static PatientResponseDto MapToResponse(Patient p)
        {
            return new PatientResponseDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FullName = p.GetFullName(),
                IdNumber = p.IdNumber,
                DateOfBirth = p.DateOfBirth,
                Age = p.GetAge(),
                Phone = p.Phone,
                Email = p.Email,
                Address = p.Address,
                MedicalHistory = p.MedicalHistory,
                CreatedAt = p.CreatedAt,
                TotalAppointments = p.Appointments?.Count ?? 0,
                TotalHearingTests = p.HearingTests?.Count ?? 0
            };
        }
    }
}