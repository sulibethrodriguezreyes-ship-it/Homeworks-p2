using System.ComponentModel.DataAnnotations;

namespace RefugioSocialAPI.DTOs
{
    public class PersonsReadDTo
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Identification { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
    }
}
