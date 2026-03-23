using RefugioSocial.Domain.Core;

namespace RefugioSocialAPI.Entities
{
    public class Person : BaseEntity
    {
        
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Identification { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }

    }
}
