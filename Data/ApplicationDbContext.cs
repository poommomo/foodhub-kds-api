using FoodHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHub
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OrderInformation> OrderInformations { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } 
        public DbSet<OrderStatus> OrderStatuses { get; set; } 
        public DbSet<Pos> Pos { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderInformation>()
                .Property(x => x.OrderDateTime)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}