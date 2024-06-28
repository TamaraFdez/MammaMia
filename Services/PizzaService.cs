using MammaMia.Data;
using MammaMia.Models;
using Microsoft.EntityFrameworkCore;

namespace MammaMia.Services;

public class PizzaService
{
    private readonly PizzaContext _context;
    public PizzaService(PizzaContext context)
    {
        _context = context;
    }
    public IEnumerable<Pizza> GetAll()
    {
        return _context.Pizzas.AsNoTracking().ToList();
    }

    public Pizza? GetById(int id)
    {
        return _context.Pizzas
             .Include(p => p.Toppings)
             .Include(p => p.Sauce)
             .AsNoTracking()
             .SingleOrDefault(p => p.Id == id);
    }

    public Pizza? Create(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();

        return pizza;
    }

    public void AddToppping(int pizzaId, int toppingId)
    {
        var pizza = _context.Pizzas.Find(pizzaId);
        var topping = _context.Toppings.Find(toppingId);
        if(pizza is null || topping is null){
            throw new InvalidOperationException("La pizza o el ingrediente no existen");
        }

        if(pizza.Toppings is null){
            pizza.Toppings = new List<Topping>();
        }

        pizza.Toppings.Add(topping);

        _context.SaveChanges();
        
    }

    public void UpdateSauce(int pizzaId, int sauceId)
    {
        var pizza = _context.Pizzas.Find(pizzaId);
        var sauce = _context.Sauces.Find(sauceId);
        if (pizza is null || sauce is null)
        {
            throw new InvalidOperationException("La pizza o la salsa no existen");
        }

        pizza.Sauce = sauce;

        _context.SaveChanges();
    }

    public void DeleteById(int pizzaId)
    {
        var pizza = _context.Pizzas.Find(pizzaId);
        if(pizza is not null){
            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }
    }
}