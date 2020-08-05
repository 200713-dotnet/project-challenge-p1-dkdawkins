using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class PizzaModel : AModel
  {
    public CrustModel Crust { get; set; }
    public SizeModel Size { get; set; }
    public OrderModel Order { get; set; }
    public List<PizzaToppingModel> PizzaToppings { get; set; }
  }
}