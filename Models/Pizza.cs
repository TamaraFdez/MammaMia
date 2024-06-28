using System.ComponentModel.DataAnnotations;

namespace MammaMia.Models;

public class Pizza {
    
    public int Id { get; set; }
    [Required]
    [MaxLengthAttribute(100)]
    public string? Name { get; set; }
    public bool IsGlutenFree{ get; set; }

    public Sauce? Sauce { get;set; }

    public ICollection<Topping>? Toppings{ get;set; }
}