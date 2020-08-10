using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class StoreOrdersViewModel
  {
    public StoreModel Store { get; set; }
    public string UserName { get; set; }

    public decimal ViewPizzaPrice(PizzaModel pizza) 
    {
      decimal price = 0.00m;

      price += (pizza.Size.Price + pizza.Crust.Price);
      foreach (var pt in pizza.PizzaToppings)
      {
        price += pt.Topping.Price;
      }

      return price;
    }
    
    public decimal ViewOrderPrice(OrderModel order)
    {
      decimal price = 0.00m;

      foreach(var pizza in order.Pizzas)
      {
        price += (pizza.Size.Price + pizza.Crust.Price);
        foreach (var pt in pizza.PizzaToppings)
        {
          price += pt.Topping.Price;
        }
      }

      return price;
    }
  }
}