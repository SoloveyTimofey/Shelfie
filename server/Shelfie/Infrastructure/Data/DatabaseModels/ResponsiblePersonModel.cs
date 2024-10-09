using System.ComponentModel.DataAnnotations;

namespace Shelfie.Infrastructure.Data.DatabaseModels
{
    public class ResponsiblePersonModel : BaseDatabaseModel
    {
        [MaxLength(100)] public string Name { get; set; } = null!;
        [Phone] public string PhoneNumber { get; set; } = null!;
        [EmailAddress] public string? Email { get; set; }

        public IEnumerable<InventoryItemModel> InventoryItems { get; set; } = [];
    }
}
