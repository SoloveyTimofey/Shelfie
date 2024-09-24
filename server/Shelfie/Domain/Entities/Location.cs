using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<InventoryItem> InventoryItems { get; set; } = [];
    }
}
