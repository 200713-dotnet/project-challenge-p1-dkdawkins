using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private PizzaBoxDbContext _db;

    public OrderRepository(PizzaBoxDbContext pizzaBoxDbContext)
    {
      _db = pizzaBoxDbContext;
    }

    public OrderModel Create(int userId, int storeId)
    {
      OrderModel order = new OrderModel()
      {
        User = _db.Users.SingleOrDefault(u => u.Id == userId),
        Store = _db.Stores.SingleOrDefault(s => s.Id == storeId),
      };
      order.Name = order.User.Name;

      _db.Orders.Add(order);
      _db.SaveChanges();
      return order;
    }

    public void CreateCustomPizza(string crust, string size, List<string> toppings, int orderId)
    {
      //Create new Pizza
      PizzaModel pizza = new PizzaModel()
      {
        Crust = _db.Crusts.SingleOrDefault(c => c.Name == crust),
        Size = _db.Sizes.SingleOrDefault(s => s.Name == size),
        Order = _db.Orders.SingleOrDefault(o => o.Id == orderId),
        Name = "Custom"
      };

      //Create corresponding PizzaToppings
      foreach (var topping in toppings)
      {
        PizzaToppingModel pizzaTopping = new PizzaToppingModel()
        {
          Pizza = pizza,
          Topping = _db.Toppings.SingleOrDefault(t => t.Name == topping)
        };
        _db.PizzaToppings.Add(pizzaTopping);
        _db.SaveChanges();
      }
    }

    public void CreatePresetPizza(string name, int orderId)
    {
      PresetPizzaModel preset = _db.PresetPizzas
        .Where(p => p.Name == name)
        .Include(p => p.Crust)
        .Include(p => p.Size)
        .Include(p => p.PresetToppings).ThenInclude(pt => pt.Topping)
        .SingleOrDefault();

      PizzaModel pizza = new PizzaModel()
      {
        Crust = preset.Crust,
        Size = preset.Size,
        Order = _db.Orders.SingleOrDefault(o => o.Id == orderId),
        Name = preset.Name
      };

      foreach (var pt in preset.PresetToppings)
      {
        PizzaToppingModel pizzaTopping = new PizzaToppingModel()
        {
          Pizza = pizza,
          Topping = pt.Topping
        };
        _db.PizzaToppings.Add(pizzaTopping);
        _db.SaveChanges();
      }
    }

    public void DeletePizzas(int orderId)
    {
      OrderModel order = _db.Orders
        .Where(o => o.Id == orderId)
        .Include(o => o.Pizzas).ThenInclude(p => p.PizzaToppings)
        .SingleOrDefault();

      foreach (var pizza in order.Pizzas.ToList())
      {
        foreach (var pt in pizza.PizzaToppings.ToList())
        {
          _db.PizzaToppings.Attach(pt);
          _db.PizzaToppings.Remove(pt);
          _db.SaveChanges();
        }
        _db.Pizzas.Attach(pizza);
        _db.Pizzas.Remove(pizza);
        _db.SaveChanges();
      }
    }

    public OrderModel Read(int id)
    {
      return _db.Orders
        .Where(o => o.Id == id)
        .Include(o => o.User)
        .Include(o => o.Store)
        .Include(o => o.Pizzas).ThenInclude(p => p.Crust)
        .Include(o => o.Pizzas).ThenInclude(p => p.Size)
        .Include(o => o.Pizzas).ThenInclude(p => p.PizzaToppings).ThenInclude(pt => pt.Topping) //Is there a better way to do this?
        .SingleOrDefault();
    }

    public List<PresetPizzaModel> ReadPresetPizzas()
    {
      return _db.PresetPizzas.ToList();
    }

    public List<CrustModel> ReadCrusts()
    {
      return _db.Crusts.ToList();
    }

    public List<SizeModel> ReadSizes()
    {
      return _db.Sizes.ToList();
    }

    public List<ToppingModel> ReadToppings()
    {
      return _db.Toppings.ToList();
    }
  }
}