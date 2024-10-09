using Shelfie.Domain.Enums;
using Shelfie.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelfie.Infrastructure.Data.DatabaseModels
{
    public class InventoryItemModel : BaseDatabaseModel
    {
        [MaxLength(200)] public string Name { get; set; } = null!;
        public InventoryItemStatus Status { get; set; }
        [Column(TypeName = "decimal(18, 2)")] public decimal Price { get; set; }

        public BrandModel Brand { get; set; } = null!;

        public LocationModel Location {get;set;} = null!;

        public ItemTypeModel ItemType { get; set; } = null!;

        public List<ChangeLogModel> ChangeLogs { get; set; } = [];
    }
}
