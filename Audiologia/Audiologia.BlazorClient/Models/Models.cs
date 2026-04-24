namespace Audiologia.BlazorClient.Models
{
    public class PatientModel
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
        public int TotalAppointments { get; set; }
        public int TotalHearingTests { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PatientCreateModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-30);
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
    }

    public class SpecialistModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class SpecialistCreateModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class AppointmentModel
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

    public class AppointmentCreateModel
    {
        public DateTime ScheduledAt { get; set; } = DateTime.Now.AddDays(1);
        public string Reason { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = "First Visit";
        public string Notes { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public int SpecialistId { get; set; }
    }

    public class HearingTestModel
    {
        public int Id { get; set; }
        public string TestType { get; set; } = string.Empty;
        public DateTime TestDate { get; set; }
        public string RightEarLoss { get; set; } = string.Empty;
        public string LeftEarLoss { get; set; } = string.Empty;
        public string DetailedResults { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string Recommendations { get; set; } = string.Empty;
        public bool RequiresHearingAid { get; set; }
        public double? Frequency500Hz { get; set; }
        public double? Frequency1000Hz { get; set; }
        public double? Frequency2000Hz { get; set; }
        public double? Frequency4000Hz { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public int? AppointmentId { get; set; }
        public bool HasHearingLoss { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class HearingTestCreateModel
    {
        public int TestType { get; set; } = 0;
        public DateTime TestDate { get; set; } = DateTime.Today;
        public int RightEarLoss { get; set; } = 0;
        public int LeftEarLoss { get; set; } = 0;
        public string DetailedResults { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string Recommendations { get; set; } = string.Empty;
        public bool RequiresHearingAid { get; set; }
        public double? Frequency500Hz { get; set; }
        public double? Frequency1000Hz { get; set; }
        public double? Frequency2000Hz { get; set; }
        public double? Frequency4000Hz { get; set; }
        public int PatientId { get; set; }
        public int? AppointmentId { get; set; }
    }
}