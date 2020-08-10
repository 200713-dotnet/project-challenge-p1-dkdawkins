using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class ToppingModel : AModel
  {
    
    public decimal Price { get; set; }
    public List<PizzaToppingModel> PizzaToppings { get; set; }
    public List<PresetToppingModel> PresetToppings { get; set; }
  }
}