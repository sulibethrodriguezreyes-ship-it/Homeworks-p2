using Audiologia.Application.Interfaces;
using Audiologia.Domain.Entities;
using Audiologia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audiologia.Infrastructure.Repositories
{
    public class SpecialistRepository : Repository<Specialist>, ISpecialistRepository
    {
        public SpecialistRepository(AudiologiaDbContext context) : base(context) { }

        public async Task<IEnumerable<Specialist>> GetActiveAsync()
        {
            return await _context.Specialists
                .Where(s => s.IsActive)
                .ToListAsync();
        }

        public async Task<Specialist?> GetByLicenseNumberAsync(string licenseNumber)
        {
            return await _context.Specialists
                .FirstOrDefaultAsync(s => s.LicenseNumber == licenseNumber);
        }
    }
}