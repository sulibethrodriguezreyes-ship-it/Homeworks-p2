using Microsoft.EntityFrameworkCore;
using RefugioSocial.Infrastructure.Context;
using RefugioSocial.Domain.Interfaces;
using RefugioSocialAPI.Entities;

namespace RefugioSocial.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly RefugioSocialDbContext _context;

        public PersonRepository(RefugioSocialDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task CreateAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}