using System.ComponentModel.DataAnnotations;

namespace Shelfie.Infrastructure.Data.DatabaseModels
{
    public class ItemTypeModel : BaseDatabaseModel
    {
        [MaxLength(100)] public string Name { get; set; } = null!;
        public IEnumerable<InventoryItemModel> InventoryItems { get; set; } = [];
    }
}
