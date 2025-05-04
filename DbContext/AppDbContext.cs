using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.dbcontext;

public class AppDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDish> OrderDishes { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredient>()
            .HasKey(di => new { di.DishId, di.IngredientId });
        
        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Dish)
            .WithMany(d => d.Ingredients)
            .HasForeignKey(di => di.DishId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Ingredient)
            .WithMany(i => i.Dishes)
            .HasForeignKey(di => di.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderDish>()
            .HasKey(od => new { od.DishId, od.OrderId });

        modelBuilder.Entity<OrderDish>()
            .HasOne(od => od.Dish)
            .WithMany(d => d.Orders)
            .HasForeignKey(od => od.DishId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderDish>()
            .HasOne(od => od.Order)
            .WithMany(o => o.Dishes)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Dish>()
            .HasIndex(d => new { d.Name, d.RestaurantID })
            .IsUnique();
    }
}