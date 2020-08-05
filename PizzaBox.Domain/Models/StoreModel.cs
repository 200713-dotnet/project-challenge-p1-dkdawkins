using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class StoreModel : AModel
  {
    public List<OrderModel> Orders { get; set; }
  }
}