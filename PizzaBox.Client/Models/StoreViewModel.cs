using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
    public List<StoreModel> Stores { get; set; }

    //TODO: Get stores from database
    public StoreViewModel()  //DELETE OR REPLACE THIS
    {
      Stores = new List<StoreModel>
      {
        new StoreModel(){Name = "PizzaHut"},
        new StoreModel(){Name = "Dominos"}
      };
    }
    
    [Required(ErrorMessage = "Please enter your store.")]
    public string Name { get; set; }
  }
}