namespace RefugioSocialAPI.Entities
{
    public class Stay
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int PersonId { get; set; }
        
    }
}
