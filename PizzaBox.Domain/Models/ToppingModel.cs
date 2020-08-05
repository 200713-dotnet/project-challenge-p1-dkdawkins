using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class ToppingModel : AModel
  {
    public List<PizzaToppingModel> PizzaToppings { get; set; }
  }
}