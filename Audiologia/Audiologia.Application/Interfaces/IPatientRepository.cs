using Audiologia.Domain.Entities;

namespace Audiologia.Application.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Patient>> GetAllWithDetailsAsync();
        Task<Patient?> GetByIdNumberAsync(string idNumber);
        Task<IEnumerable<Patient>> SearchByNameAsync(string name);
    }
}