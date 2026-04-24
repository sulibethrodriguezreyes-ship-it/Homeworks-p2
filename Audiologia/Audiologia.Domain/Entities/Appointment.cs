namespace Audiologia.Domain.Entities
{
    public enum AppointmentStatus
    {
        Pending = 0,
        Confirmed = 1,
        Completed = 2,
        Cancelled = 3,
        NoShow = 4
    }

    public class Appointment : BaseEntity
    {
        public DateTime ScheduledAt { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string Reason { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; } = null!;

        public HearingTest? HearingTest { get; set; }

        public Appointment() { }

        public Appointment(DateTime scheduledAt, int patientId, int specialistId, string reason)
        {
            ScheduledAt = scheduledAt;
            PatientId = patientId;
            SpecialistId = specialistId;
            Reason = reason;
            Status = AppointmentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public Appointment(DateTime scheduledAt, int patientId, int specialistId,
                           string reason, string appointmentType, string notes)
        {
            ScheduledAt = scheduledAt;
            PatientId = patientId;
            SpecialistId = specialistId;
            Reason = reason;
            AppointmentType = appointmentType;
            Notes = notes;
            Status = AppointmentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public override string GetDescription()
        {
            return $"Appointment #{Id} | Date: {ScheduledAt:dd/MM/yyyy HH:mm} | Status: {Status} | Reason: {Reason}";
        }

        public bool IsActive()
        {
            return Status == AppointmentStatus.Pending || Status == AppointmentStatus.Confirmed;
        }

        public bool CanCancel()
        {
            return Status == AppointmentStatus.Pending || Status == AppointmentStatus.Confirmed;
        }

        public void ChangeStatus(AppointmentStatus newStatus)
        {
            Status = newStatus;
        }

        public void ChangeStatus(AppointmentStatus newStatus, string note)
        {
            Status = newStatus;
            Notes = note;
        }
    }
}