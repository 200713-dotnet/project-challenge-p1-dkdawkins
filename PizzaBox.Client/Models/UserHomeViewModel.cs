using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class UserHomeViewModel
  {
    public UserModel User { get; set; }
    public StoreModel Store { get; set; }
  }
}