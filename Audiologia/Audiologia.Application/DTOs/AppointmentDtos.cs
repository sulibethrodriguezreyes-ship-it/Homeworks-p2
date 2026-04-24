using Audiologia.Domain.Entities;

namespace Audiologia.Application.DTOs
{
    public class AppointmentCreateDto
    {
        public DateTime ScheduledAt { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public int SpecialistId { get; set; }
    }

    public class AppointmentUpdateDto
    {
        public DateTime ScheduledAt { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public AppointmentStatus Status { get; set; }
    }

    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public int SpecialistId { get; set; }
        public string SpecialistName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}