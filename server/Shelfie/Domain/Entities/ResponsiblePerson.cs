using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ResponsiblePerson
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }

        public IEnumerable<InventoryItem> InventoryItems { get; set; } = [];
    }
}
