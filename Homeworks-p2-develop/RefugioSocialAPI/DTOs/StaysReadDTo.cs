namespace RefugioSocialAPI.DTOs
{
    public class StaysReadDTo
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int PersonId { get; set; }
    }
}
