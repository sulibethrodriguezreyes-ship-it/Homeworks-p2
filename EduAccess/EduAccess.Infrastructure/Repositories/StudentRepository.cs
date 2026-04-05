using EduAccess.Domain.Entities;
using EduAccess.Infrastructure.Context;
using EduAccess.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduAccess.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EduContext _context;

        public StudentRepository(EduContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync(); // Guarda en SQL
            return student;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}