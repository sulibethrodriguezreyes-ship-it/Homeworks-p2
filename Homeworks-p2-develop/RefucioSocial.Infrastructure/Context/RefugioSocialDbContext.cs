using Microsoft.EntityFrameworkCore;
using RefugioSocialAPI.Entities;


namespace RefugioSocial.Infrastructure.Context

{
    public class RefugioSocialDbContext : DbContext
    {
       public RefugioSocialDbContext(DbContextOptions<RefugioSocialDbContext> options) 
            : base(options)
        { 
        }

        public DbSet<Person> Persons { get; set; }
        
        public DbSet<Stay> Stays { get; set; }

    }


}
