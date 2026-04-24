using Audiologia.Application.Interfaces;
using Audiologia.Domain.Entities;
using Audiologia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Audiologia.Infrastructure.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AudiologiaDbContext context) : base(context) { }

        public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Specialist)
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.ScheduledAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetBySpecialistIdAsync(int specialistId)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Specialist)
                .Where(a => a.SpecialistId == specialistId)
                .OrderByDescending(a => a.ScheduledAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Specialist)
                .Where(a => a.ScheduledAt.Date == date.Date)
                .OrderBy(a => a.ScheduledAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetWithDetailsAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Specialist)
                .OrderByDescending(a => a.ScheduledAt)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Specialist)
                .Include(a => a.HearingTest)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}