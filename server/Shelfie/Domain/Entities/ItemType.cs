namespace Shelfie.Domain.Entities
{
    public class ItemType : BaseEntity
    {
        public string Name { get; set; } = null!;

        public IEnumerable<InventoryItem> InventoryItems { get; set; } = [];
    }
}
