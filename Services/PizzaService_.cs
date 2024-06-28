// using MammaMia.Models;

// namespace MammaMia.Services;

// public static class PizzaService
// {
//     static List<Pizza> Pizzas { get; }
//     static int nextId = 3;

//     static PizzaService()
//     {
//         Pizzas = new List<Pizza> {
//             new Pizza { Id = 1, Name = "Margarita", IsGlutenFree = true},
//             new Pizza { Id = 2, Name = "Pepperoni", IsGlutenFree = false}
//         };
//     }

//     public static List<Pizza> GetPizzas() => Pizzas;

//     public static Pizza? GetPizza(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

//     public static void AddPizza(Pizza pizza)
//     {
//         pizza.Id = nextId++;
//        Pizzas .Add(pizza);
//     }

//     public static void RemovePizza(int id)
//     {
//         var pizza = GetPizza(id);

//         if (pizza is null) return;

//         Pizzas.Remove(pizza);
//     }

//     public static void UpdatePizza(Pizza pizza)
//     {
//         var index = Pizzas.FindIndex(p => p.Id == pizza.Id);

//         if (index == -1) return;

//         Pizzas[index] = pizza;
//     }
    
// }