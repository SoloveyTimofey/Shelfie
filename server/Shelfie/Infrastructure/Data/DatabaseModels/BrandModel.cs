namespace Shelfie.Infrastructure.Data.DatabaseModels
{
    public class BrandModel : BaseDatabaseModel
    {
        public string Name { get; set; } = null!;
        public IEnumerable<InventoryItemModel> InventoryItems { get; set; } = [];
    }
}
