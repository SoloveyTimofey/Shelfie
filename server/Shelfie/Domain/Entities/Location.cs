using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; } = null!;

        public IEnumerable<InventoryItem> InventoryItems { get; set; } = [];
    }
}
