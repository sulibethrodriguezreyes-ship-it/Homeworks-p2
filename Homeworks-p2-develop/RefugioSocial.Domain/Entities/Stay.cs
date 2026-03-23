using RefugioSocial.Domain.Core;

namespace RefugioSocialAPI.Entities
{
    public class Stay : BaseEntity
    {
        
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int PersonId { get; set; }
        
    }
}
