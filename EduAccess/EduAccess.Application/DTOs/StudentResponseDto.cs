namespace EduAccess.Application.DTOs
{
    public class StudentResponseDto
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Community { get; set; } = string.Empty;
        public bool HasInternet { get; set; }
        public string DeviceType { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public string ConnectivityStatus => HasInternet ? "Conectado" : "Brecha Digital";
    }
}