using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
    public List<StoreModel> Stores { get; set; }
    
    [Required(ErrorMessage = "Please enter your store.")]
    public string Name { get; set; }
  }
}