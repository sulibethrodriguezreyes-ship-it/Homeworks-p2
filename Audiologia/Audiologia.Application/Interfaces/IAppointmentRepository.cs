using Audiologia.Domain.Entities;

namespace Audiologia.Application.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<Appointment>> GetBySpecialistIdAsync(int specialistId);
        Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date);
        Task<IEnumerable<Appointment>> GetWithDetailsAsync();
        Task<Appointment?> GetByIdWithDetailsAsync(int id);
    }
}