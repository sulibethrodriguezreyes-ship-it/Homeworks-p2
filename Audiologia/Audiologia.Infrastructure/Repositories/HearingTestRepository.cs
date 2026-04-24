using Audiologia.Application.Interfaces;
using Audiologia.Domain.Entities;
using Audiologia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audiologia.Infrastructure.Repositories
{
    public class HearingTestRepository : Repository<HearingTest>, IHearingTestRepository
    {
        public HearingTestRepository(AudiologiaDbContext context) : base(context) { }

        public async Task<IEnumerable<HearingTest>> GetByPatientIdAsync(int patientId)
        {
            return await _context.HearingTests
                .Include(h => h.Patient)
                .Where(h => h.PatientId == patientId)
                .OrderByDescending(h => h.TestDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<HearingTest>> GetWithDetailsAsync()
        {
            return await _context.HearingTests
                .Include(h => h.Patient)
                .Include(h => h.Appointment)
                .OrderByDescending(h => h.TestDate)
                .ToListAsync();
        }

        public async Task<HearingTest?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.HearingTests
                .Include(h => h.Patient)
                .Include(h => h.Appointment)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<HearingTest>> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _context.HearingTests
                .Include(h => h.Patient)
                .Where(h => h.AppointmentId == appointmentId)
                .ToListAsync();
        }
    }
}