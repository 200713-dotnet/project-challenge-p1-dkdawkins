using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class PresetPizzaViewModel
  {
    public List<PresetPizzaModel> PresetPizzas { get; set; }

    [Required(ErrorMessage = "Please select a Pizza.")]
    public string Name { get; set; }
  }
}