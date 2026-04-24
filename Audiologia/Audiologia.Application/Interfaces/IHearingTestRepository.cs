using Audiologia.Domain.Entities;

namespace Audiologia.Application.Interfaces
{
    public interface IHearingTestRepository : IRepository<HearingTest>
    {
        Task<IEnumerable<HearingTest>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<HearingTest>> GetWithDetailsAsync();
        Task<HearingTest?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<HearingTest>> GetByAppointmentIdAsync(int appointmentId);
    }
}