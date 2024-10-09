using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shelfie.Domain.ValueObjects;
using Shelfie.Infrastructure.Data.DatabaseModels;
using Shelfie.Infrastructure.Identity;

namespace Shelfie.Infrastructure.Data.DbContexts
{
    public class ShelfieDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShelfieDbContext(DbContextOptions<ShelfieDbContext> options):base(options) { }

        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<InventoryItemModel> InventoryItems { get; set; }
        public DbSet<QuantativeInventoryItemModel> QuantativeInventoryItems { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<ResponsiblePersonModel> ResponsiblePeople { get; set; }
        public DbSet<ItemTypeModel> ItemTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItemModel>().OwnsOne(
                inventoryItem => inventoryItem.ChangeLogs, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
