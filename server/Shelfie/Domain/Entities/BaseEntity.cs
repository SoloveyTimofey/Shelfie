namespace Shelfie.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public string CreatorId { get; set; } = string.Empty;
    }
}
