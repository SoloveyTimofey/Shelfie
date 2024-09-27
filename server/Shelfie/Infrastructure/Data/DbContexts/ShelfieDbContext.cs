using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data.DbContexts
{
    public class ShelfieDbContext : DbContext
    {
        public ShelfieDbContext(DbContextOptions<ShelfieDbContext> options):base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<QuantativeInventoryItem> QuantativeInventoryItems { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ResponsiblePerson> ResponsiblePeople { get; set; }
        public DbSet<ItemType> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>().Property(nameof(InventoryItem.Price)).HasColumnType("decimal");
            modelBuilder.Entity<InventoryItem>().OwnsOne(
                inventoryItem => inventoryItem.ChangeLogs, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
