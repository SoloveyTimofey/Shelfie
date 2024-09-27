using Shelfie.Domain.Enums;
using Shelfie.Domain.ValueObjects;

namespace Shelfie.Domain.Entities
{
    public class InventoryItem : BaseEntity
    {
        public string Name { get; set; } = null!;
        public InventoryItemStatus Status { get; set; }
        public decimal Price { get; set; }

        //public long BrandId;
        public Brand Brand { get; set; } = null!;

        //public long LocationId;
        public Location Location { get; set; } = null!;

        public List<ChangeLog> ChangeLogs { get; set; } = [];
    }
}
