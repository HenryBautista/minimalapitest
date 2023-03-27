using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Services;

public class BussinesLogic
{
    private readonly PizzaDb PizzaDb;

    public BussinesLogic(PizzaDb pizzaDb)
    {
        PizzaDb = pizzaDb;
        PizzaDb.Add(new Pizza {
            Id = Guid.NewGuid(),
            Name = "Only Cheesse"
        });
        PizzaDb.SaveChanges();
    }

    public int Sum(int a, int b) => a + b;

    public async Task<IReadOnlyList<Pizza>> Get()
    {
        var pizzas = await PizzaDb.Pizzas.ToListAsync(); 

        if (pizzas.Count == 0)
        {
            return Array.Empty<Pizza>();
        }

        return pizzas;
    }
}