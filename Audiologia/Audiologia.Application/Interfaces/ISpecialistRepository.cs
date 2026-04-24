using Audiologia.Domain.Entities;

namespace Audiologia.Application.Interfaces
{
    public interface ISpecialistRepository : IRepository<Specialist>
    {
        Task<IEnumerable<Specialist>> GetActiveAsync();
        Task<Specialist?> GetByLicenseNumberAsync(string licenseNumber);
    }
}