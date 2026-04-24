namespace Audiologia.Domain.Entities
{
    public class Specialist : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public Specialist() { }

        public Specialist(string firstName, string lastName, string licenseNumber, string specialty)
        {
            FirstName = firstName;
            LastName = lastName;
            LicenseNumber = licenseNumber;
            Specialty = specialty;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public override string GetDescription()
        {
            return $"Dr. {FirstName} {LastName} | License: {LicenseNumber} | Specialty: {Specialty}";
        }

        public bool CanAttend()
        {
            return IsActive;
        }

        public string GetFullName()
        {
            return $"Dr. {FirstName} {LastName}";
        }

        public string GetFullName(bool includeSpecialty)
        {
            if (includeSpecialty)
                return $"Dr. {FirstName} {LastName} - {Specialty}";
            return $"Dr. {FirstName} {LastName}";
        }
    }
}