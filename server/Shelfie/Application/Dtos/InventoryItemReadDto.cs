using Shelfie.Domain.Entities;
using Shelfie.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelfie.Application.Dtos
{
    public record InventoryItemReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public InventoryItemStatus Status { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; } = null!;
        public Location Location { get; set; } = null!;
    }
}
