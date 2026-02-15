namespace RefugioSocialAPI.DTOs
{
    public class StaysCreateDTo
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int PersonId { get; set; }
    }
}
