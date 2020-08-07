using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class UserViewModel
  {
    public List<StoreModel> Stores { get; set; }
    
    [Required(ErrorMessage = "Please enter a name.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please select a store.")]
    public string Store { get; set; }
  }
}