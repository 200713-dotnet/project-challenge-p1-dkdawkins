using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class UserModel : AModel
  {
    public List<OrderModel> Orders { get; set; }
  }
}