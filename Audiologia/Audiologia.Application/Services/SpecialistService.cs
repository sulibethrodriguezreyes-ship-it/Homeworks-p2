using Audiologia.Application.DTOs;
using Audiologia.Application.Interfaces;
using Audiologia.Application.Services.Interfaces;
using Audiologia.Domain.Entities;

namespace Audiologia.Application.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly ISpecialistRepository _repo;

        public SpecialistService(ISpecialistRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SpecialistResponseDto>> GetAllAsync()
        {
            var specialists = await _repo.GetAllAsync();
            return specialists.Select(MapToResponse);
        }

        public async Task<SpecialistResponseDto?> GetByIdAsync(int id)
        {
            var specialist = await _repo.GetByIdAsync(id);
            return specialist is null ? null : MapToResponse(specialist);
        }

        public async Task<SpecialistResponseDto> CreateAsync(SpecialistCreateDto dto)
        {
            var existing = await _repo.GetByLicenseNumberAsync(dto.LicenseNumber);
            if (existing is not null)
                throw new InvalidOperationException($"A specialist with license {dto.LicenseNumber} already exists.");

            var specialist = new Specialist(dto.FirstName, dto.LastName, dto.LicenseNumber, dto.Specialty)
            {
                Phone = dto.Phone,
                Email = dto.Email
            };

            var created = await _repo.AddAsync(specialist);
            return MapToResponse(created);
        }

        public async Task<SpecialistResponseDto?> UpdateAsync(int id, SpecialistUpdateDto dto)
        {
            var specialist = await _repo.GetByIdAsync(id);
            if (specialist is null) return null;

            specialist.FirstName = dto.FirstName;
            specialist.LastName = dto.LastName;
            specialist.Specialty = dto.Specialty;
            specialist.Phone = dto.Phone;
            specialist.Email = dto.Email;
            specialist.IsActive = dto.IsActive;

            var updated = await _repo.UpdateAsync(specialist);
            return MapToResponse(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repo.ExistsAsync(id)) return false;
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<SpecialistResponseDto>> GetActiveAsync()
        {
            var specialists = await _repo.GetActiveAsync();
            return specialists.Select(MapToResponse);
        }

        private static SpecialistResponseDto MapToResponse(Specialist s)
        {
            return new SpecialistResponseDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                FullName = s.GetFullName(true),
                LicenseNumber = s.LicenseNumber,
                Specialty = s.Specialty,
                Phone = s.Phone,
                Email = s.Email,
                IsActive = s.IsActive,
                CreatedAt = s.CreatedAt
            };
        }
    }
}