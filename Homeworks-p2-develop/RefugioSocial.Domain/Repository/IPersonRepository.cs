using RefugioSocialAPI.Entities;

namespace RefugioSocial.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(int id);
        Task CreateAsync(Person person);
        void Delete(Person person);
        Task<bool> SaveChangesAsync();
    }
}