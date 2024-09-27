namespace Shelfie.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; } = null!;

        public IEnumerable<InventoryItem> InventoryItems { get; set; } = [];
    }
}
