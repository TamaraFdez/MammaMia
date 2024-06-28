using MammaMia.Models;
using MammaMia.Services;
using Microsoft.AspNetCore.Mvc;

namespace MammaMia.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private PizzaService _service;
    public PizzaController(PizzaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetPizzas() => Ok(_service.GetAll());
    [HttpGet("{id}")]
    public ActionResult<Pizza> GetPizza(int id)
    {
        var pizza = _service.GetById(id);

        if (pizza == null) return NotFound();

        return Ok(pizza);
    }

    [HttpPost]
    public IActionResult CreatePizza(Pizza pizza)
    {
        _service.Create(pizza);
        return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}/addtopping")]
    public IActionResult AddTopping(int id, int toppingId)
    {
        var pizza = _service.GetById(id);
        if (pizza is null) return NotFound();

        _service.AddToppping(id, toppingId);
        return NoContent();

    }
    //TODO UPDATE SAUCE

    [HttpDelete("{id}")]
    public IActionResult RemovePizza(int id)
    {
        var pizza = _service.GetById(id);

        if (pizza is null) return NotFound();

        _service.DeleteById(id);

        return NoContent();
    }
}