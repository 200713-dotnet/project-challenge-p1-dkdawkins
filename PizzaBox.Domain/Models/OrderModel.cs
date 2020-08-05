using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class OrderModel : AModel
  {
    public StoreModel Store { get; set; }
    public UserModel User { get; set; }
    public List<PizzaModel> Pizzas { get; set; }
  }
}