namespace Shelfie.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;

        public IEnumerable<InventoryItem> InventoryItems { get; set; } = [];
    }
}
