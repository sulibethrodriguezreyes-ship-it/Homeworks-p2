using Audiologia.Domain.Entities;

namespace Audiologia.Application.DTOs
{
    public class HearingTestCreateDto
    {
        public TestType TestType { get; set; }
        public DateTime TestDate { get; set; }
        public HearingLossGrade RightEarLoss { get; set; }
        public HearingLossGrade LeftEarLoss { get; set; }
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

    public class HearingTestUpdateDto
    {
        public HearingLossGrade RightEarLoss { get; set; }
        public HearingLossGrade LeftEarLoss { get; set; }
        public string DetailedResults { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string Recommendations { get; set; } = string.Empty;
        public bool RequiresHearingAid { get; set; }
        public double? Frequency500Hz { get; set; }
        public double? Frequency1000Hz { get; set; }
        public double? Frequency2000Hz { get; set; }
        public double? Frequency4000Hz { get; set; }
    }

    public class HearingTestResponseDto
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
}