namespace Audiologia.Application.DTOs
{
    public class PatientCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
    }

    public class PatientUpdateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
    }

    public class PatientResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int TotalAppointments { get; set; }
        public int TotalHearingTests { get; set; }
    }
}