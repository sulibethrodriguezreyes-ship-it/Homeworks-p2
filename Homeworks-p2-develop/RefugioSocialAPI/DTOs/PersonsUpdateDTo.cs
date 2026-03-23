using System.ComponentModel.DataAnnotations;

namespace RefugioSocialAPI.DTOs
{
    public class PersonsUpdateDTo
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        public string Identification { get; set; } = string.Empty;
        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
