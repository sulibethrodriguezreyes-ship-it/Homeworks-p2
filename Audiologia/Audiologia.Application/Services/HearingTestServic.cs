using Audiologia.Application.DTOs;
using Audiologia.Application.Interfaces;
using Audiologia.Application.Services.Interfaces;
using Audiologia.Domain.Entities;

namespace Audiologia.Application.Services
{
    public class HearingTestService : IHearingTestService
    {
        private readonly IHearingTestRepository _repo;
        private readonly IPatientRepository _patientRepo;

        public HearingTestService(IHearingTestRepository repo, IPatientRepository patientRepo)
        {
            _repo = repo;
            _patientRepo = patientRepo;
        }

        public async Task<IEnumerable<HearingTestResponseDto>> GetAllAsync()
        {
            var tests = await _repo.GetWithDetailsAsync();
            return tests.Select(MapToResponse);
        }

        public async Task<HearingTestResponseDto?> GetByIdAsync(int id)
        {
            var test = await _repo.GetByIdWithDetailsAsync(id);
            return test is null ? null : MapToResponse(test);
        }

        public async Task<HearingTestResponseDto> CreateAsync(HearingTestCreateDto dto)
        {
            if (!await _patientRepo.ExistsAsync(dto.PatientId))
                throw new InvalidOperationException("The patient does not exist.");

            var test = new HearingTest(
                dto.PatientId,
                dto.TestType,
                dto.TestDate,
                dto.RightEarLoss,
                dto.LeftEarLoss,
                dto.DetailedResults,
                dto.Observations
            );

            test.Recommendations = dto.Recommendations;
            test.RequiresHearingAid = dto.RequiresHearingAid;
            test.Frequency500Hz = dto.Frequency500Hz;
            test.Frequency1000Hz = dto.Frequency1000Hz;
            test.Frequency2000Hz = dto.Frequency2000Hz;
            test.Frequency4000Hz = dto.Frequency4000Hz;
            test.AppointmentId = dto.AppointmentId;

            var created = await _repo.AddAsync(test);
            var withDetails = await _repo.GetByIdWithDetailsAsync(created.Id);

            return MapToResponse(withDetails!);
        }

        public async Task<HearingTestResponseDto?> UpdateAsync(int id, HearingTestUpdateDto dto)
        {
            var test = await _repo.GetByIdAsync(id);
            if (test is null) return null;

            test.RightEarLoss = dto.RightEarLoss;
            test.LeftEarLoss = dto.LeftEarLoss;
            test.DetailedResults = dto.DetailedResults;
            test.Observations = dto.Observations;
            test.Recommendations = dto.Recommendations;
            test.RequiresHearingAid = dto.RequiresHearingAid;
            test.Frequency500Hz = dto.Frequency500Hz;
            test.Frequency1000Hz = dto.Frequency1000Hz;
            test.Frequency2000Hz = dto.Frequency2000Hz;
            test.Frequency4000Hz = dto.Frequency4000Hz;

            var updated = await _repo.UpdateAsync(test);
            var withDetails = await _repo.GetByIdWithDetailsAsync(updated.Id);

            return MapToResponse(withDetails!);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repo.ExistsAsync(id)) return false;
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<HearingTestResponseDto>> GetByPatientAsync(int patientId)
        {
            var tests = await _repo.GetByPatientIdAsync(patientId);
            return tests.Select(MapToResponse);
        }

        private static HearingTestResponseDto MapToResponse(HearingTest h)
        {
            return new HearingTestResponseDto
            {
                Id = h.Id,
                TestType = h.TestType.ToString(),
                TestDate = h.TestDate,
                RightEarLoss = h.RightEarLoss.ToString(),
                LeftEarLoss = h.LeftEarLoss.ToString(),
                DetailedResults = h.DetailedResults,
                Observations = h.Observations,
                Recommendations = h.Recommendations,
                RequiresHearingAid = h.RequiresHearingAid,
                Frequency500Hz = h.Frequency500Hz,
                Frequency1000Hz = h.Frequency1000Hz,
                Frequency2000Hz = h.Frequency2000Hz,
                Frequency4000Hz = h.Frequency4000Hz,
                PatientId = h.PatientId,
                PatientName = h.Patient?.GetFullName() ?? "",
                AppointmentId = h.AppointmentId,
                HasHearingLoss = h.HasHearingLoss(),
                CreatedAt = h.CreatedAt
            };
        }
    }
}