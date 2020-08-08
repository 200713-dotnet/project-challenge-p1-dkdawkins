using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class CustomPizzaViewModel
  {
    public List<CrustModel> Crusts { get; set; }
    public List<SizeModel> Sizes { get; set; }
    public List<ToppingModel> Toppings { get; set; }


    [Required(ErrorMessage = "Please select a crust.")]
    public string Crust { get; set; }
    [Required(ErrorMessage = "Please select a size.")]
    public string Size { get; set; }
    [Required(ErrorMessage = "Please select toppings.")]
    public List<string> SelectedToppings { get; set; }
  }
}