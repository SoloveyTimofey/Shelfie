using System.ComponentModel.DataAnnotations;

namespace Shelfie.Infrastructure.Data.DatabaseModels
{
    public class LocationModel : BaseDatabaseModel
    {
        [MaxLength(200)] public string Name { get; set; } = null!;

        public IEnumerable<InventoryItemModel> InventoryItems { get; set; } = [];
    }
}
