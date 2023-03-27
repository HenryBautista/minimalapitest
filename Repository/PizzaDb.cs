using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Repository;
public class PizzaDb : DbContext
{
    public PizzaDb(DbContextOptions options) : base (options) {}
    public DbSet<Pizza> Pizzas { get; set; } = null!;
}