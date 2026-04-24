namespace Audiologia.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<HearingTest> HearingTests { get; set; } = new List<HearingTest>();

        public Patient() { }

        public Patient(string firstName, string lastName, string idNumber, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            DateOfBirth = dateOfBirth;
            CreatedAt = DateTime.UtcNow;
        }

        public Patient(string firstName, string lastName, string idNumber,
                       DateTime dateOfBirth, string phone,
                       string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Address = address;
            CreatedAt = DateTime.UtcNow;
        }

        public override string GetDescription()
        {
            return $"Patient: {FirstName} {LastName} | ID: {IdNumber} | Phone: {Phone}";
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public string GetFullName(bool includeId)
        {
            if (includeId)
                return $"{FirstName} {LastName} ({IdNumber})";
            return $"{FirstName} {LastName}";
        }
    }
}