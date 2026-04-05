using System.ComponentModel.DataAnnotations;

namespace EduAccess.Domain.DTOs
{
    public class StudentCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Community { get; set; } = string.Empty;

        public bool HasInternet { get; set; }

        public string DeviceType { get; set; } = "Ninguno";
    }
}