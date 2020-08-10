using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<PizzaModel> Pizzas { get; set; }
    public DbSet<PresetPizzaModel> PresetPizzas { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<StoreModel> Stores { get; set; }
    public DbSet<ToppingModel> Toppings { get; set; }
    public DbSet<SizeModel> Sizes { get; set; }
    public DbSet<CrustModel> Crusts { get; set; }
    public DbSet<PizzaToppingModel> PizzaToppings { get; set; }
    public DbSet<PresetToppingModel> PresetToppings { get; set; }

    public PizzaBoxDbContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<PizzaModel>().HasKey(e => e.Id);
      builder.Entity<PresetPizzaModel>().HasKey(e => e.Id);
      builder.Entity<CrustModel>().HasKey(e => e.Id);
      builder.Entity<SizeModel>().HasKey(e => e.Id);
      builder.Entity<ToppingModel>().HasKey(e => e.Id);
      builder.Entity<OrderModel>().HasKey(e => e.Id);
      builder.Entity<StoreModel>().HasKey(e => e.Id);
      builder.Entity<UserModel>().HasKey(e => e.Id);
      builder.Entity<PizzaToppingModel>().HasKey(e => new { e.PizzaId, e.ToppingId}); // Uses compound key
      builder.Entity<PresetToppingModel>().HasKey(e => new { e.PresetPizzaId, e.ToppingId});
      
      builder.Entity<PizzaToppingModel>()
        .HasOne(e => e.Pizza)
        .WithMany(e => e.PizzaToppings)
        .HasForeignKey(e => e.PizzaId);
      builder.Entity<PizzaToppingModel>()
        .HasOne(e => e.Topping)
        .WithMany(e => e.PizzaToppings)
        .HasForeignKey(e => e.ToppingId);

      builder.Entity<PresetToppingModel>()
        .HasOne(e => e.PresetPizza)
        .WithMany(e => e.PresetToppings)
        .HasForeignKey(e => e.PresetPizzaId);
      builder.Entity<PresetToppingModel>()
        .HasOne(e => e.Topping)
        .WithMany(e => e.PresetToppings)
        .HasForeignKey(e => e.ToppingId);
    }
  }
}