using System.ComponentModel.DataAnnotations;

namespace EduAccess.Application.DTOs
{
    public class StudentUpdateDto
    {
        [Required]
        public int StudentId { get; set; } 

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Community { get; set; } = string.Empty;

        public bool HasInternet { get; set; }

        public string DeviceType { get; set; } = "Ninguno";
    }
}