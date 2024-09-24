using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InventoryItem
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public InventoryItemStatus Status { get; set; }
        public decimal Price { get; set; }

        public long BrandId;
        public Brand Brand { get; set; } = null!;

        public long LocationId;
        public Location Location { get; set; } = null!;
    }
}
