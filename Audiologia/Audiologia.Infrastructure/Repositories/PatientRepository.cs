using Audiologia.Application.Interfaces;
using Audiologia.Domain.Entities;
using Audiologia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audiologia.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(AudiologiaDbContext context) : base(context) { }

        public async Task<Patient?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Specialist)
                .Include(p => p.HearingTests)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetAllWithDetailsAsync()
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .Include(p => p.HearingTests)
                .ToListAsync();
        }

        public async Task<Patient?> GetByIdNumberAsync(string idNumber)
        {
            return await _context.Patients
                .FirstOrDefaultAsync(p => p.IdNumber == idNumber);
        }

        public async Task<IEnumerable<Patient>> SearchByNameAsync(string name)
        {
            return await _context.Patients
                .Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name))
                .ToListAsync();
        }
    }
}