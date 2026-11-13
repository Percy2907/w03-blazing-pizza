using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaSpecial> Specials { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PizzaTopping>().HasKey(pizzaTopping => new
        {
            pizzaTopping.PizzaId,
            pizzaTopping.ToppingId
        });
        modelBuilder.Entity<PizzaTopping>()
            .HasOne<Pizza>()
            .WithMany(pizza => pizza.Toppings);
        modelBuilder.Entity<PizzaTopping>()
            .HasOne(pizzaTopping => pizzaTopping.Topping)
            .WithMany();
    }
}
