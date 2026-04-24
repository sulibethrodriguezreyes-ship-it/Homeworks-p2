namespace Audiologia.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public abstract string GetDescription();

        public override string ToString()
        {
            return $"[{GetType().Name}] Id: {Id} | Created: {CreatedAt:dd/MM/yyyy}";
        }
    }
}