namespace Audiologia.Domain.Entities
{
    public enum TestType
    {
        Audiometry = 0,
        Tympanometry = 1,
        AuditoryEvokedPotentials = 2,
        OtoacousticEmissions = 3,
        SpeechAudiometry = 4
    }

    public enum HearingLossGrade
    {
        Normal = 0,
        Mild = 1,
        Moderate = 2,
        Severe = 3,
        Profound = 4
    }

    public class HearingTest : BaseEntity
    {
        public TestType TestType { get; set; }
        public DateTime TestDate { get; set; }
        public HearingLossGrade RightEarLoss { get; set; }
        public HearingLossGrade LeftEarLoss { get; set; }
        public string DetailedResults { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string Recommendations { get; set; } = string.Empty;
        public bool RequiresHearingAid { get; set; } = false;

        public double? Frequency500Hz { get; set; }
        public double? Frequency1000Hz { get; set; }
        public double? Frequency2000Hz { get; set; }
        public double? Frequency4000Hz { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

        public HearingTest() { }

        public HearingTest(int patientId, TestType testType, DateTime testDate)
        {
            PatientId = patientId;
            TestType = testType;
            TestDate = testDate;
            CreatedAt = DateTime.UtcNow;
        }

        public HearingTest(int patientId, TestType testType, DateTime testDate,
                           HearingLossGrade rightEar, HearingLossGrade leftEar,
                           string detailedResults, string observations)
        {
            PatientId = patientId;
            TestType = testType;
            TestDate = testDate;
            RightEarLoss = rightEar;
            LeftEarLoss = leftEar;
            DetailedResults = detailedResults;
            Observations = observations;
            CreatedAt = DateTime.UtcNow;
        }

        public override string GetDescription()
        {
            return $"Test: {TestType} | Date: {TestDate:dd/MM/yyyy} | Right: {RightEarLoss} | Left: {LeftEarLoss}";
        }

        public bool HasHearingLoss()
        {
            return RightEarLoss != HearingLossGrade.Normal ||
                   LeftEarLoss != HearingLossGrade.Normal;
        }

        public string GetSummary()
        {
            return $"{TestType} - Right: {RightEarLoss} / Left: {LeftEarLoss}";
        }

        public string GetSummary(bool includeRecommendations)
        {
            var summary = GetSummary();
            if (includeRecommendations && !string.IsNullOrEmpty(Recommendations))
                return $"{summary} | Recommendations: {Recommendations}";
            return summary;
        }
    }
}