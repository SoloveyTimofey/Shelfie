namespace Shelfie.Domain.Entities
{
    public class ResponsiblePerson:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }

        public IEnumerable<InventoryItem> InventoryItems { get; set; } = [];
    }
}
