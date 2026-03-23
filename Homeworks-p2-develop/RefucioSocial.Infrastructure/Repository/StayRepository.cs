using Microsoft.EntityFrameworkCore;
using RefugioSocial.Infrastructure.Context;
using RefugioSocial.Domain.Interfaces;
using RefugioSocialAPI.Entities; // Usamos el mismo namespace que en Person

namespace RefugioSocial.Infrastructure.Repository
{
    public class StayRepository : IStayRepository
    {
        private readonly RefugioSocialDbContext _context;

        public StayRepository(RefugioSocialDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stay>> GetAllAsync()
        {
            return await _context.Stays.ToListAsync();
        }

        public async Task<Stay?> GetByIdAsync(int id)
        {
            return await _context.Stays.FindAsync(id);
        }

        public async Task CreateAsync(Stay stay)
        {
            await _context.Stays.AddAsync(stay);
        }

        public void Delete(Stay stay)
        {
            _context.Stays.Remove(stay);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}