using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class OrderMenuViewModel
  {
    public OrderModel Order { get; set; }

    public decimal ViewPrice(PizzaModel pizza) 
    {
      decimal price = 0.00m;

      price += (pizza.Size.Price + pizza.Crust.Price);
      foreach (var pt in pizza.PizzaToppings)
      {
        price += pt.Topping.Price;
      }

      return price;
    }
    
    public decimal ViewTotalPrice()
    {
      decimal price = 0.00m;

      foreach(var pizza in Order.Pizzas)
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