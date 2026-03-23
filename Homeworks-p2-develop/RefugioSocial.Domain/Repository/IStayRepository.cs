using RefugioSocialAPI.Entities;

namespace RefugioSocial.Domain.Interfaces
{
    public interface IStayRepository
    {
        Task<IEnumerable<Stay>> GetAllAsync();
        Task<Stay?> GetByIdAsync(int id);
        Task CreateAsync(Stay stay);
        void Delete(Stay stay);
        Task<bool> SaveChangesAsync();
    }
}