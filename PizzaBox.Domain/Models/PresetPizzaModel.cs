using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class PresetPizzaModel : AModel
  {
    public CrustModel Crust { get; set; }
    public SizeModel Size { get; set; }
    public List<PresetToppingModel> PresetToppings { get; set; }
  }
}