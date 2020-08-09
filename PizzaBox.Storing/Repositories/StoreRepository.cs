using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    private PizzaBoxDbContext _db;

    public StoreRepository(PizzaBoxDbContext pizzaBoxDbContext)
    {
      _db = pizzaBoxDbContext;
    }

    public StoreModel Read(string name)
    {
      return _db.Stores
        .Where(s => s.Name == name)
        .Include(s => s.Orders).ThenInclude(o => o.User)
        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.PizzaToppings).ThenInclude(p => p.Topping)
        .FirstOrDefault();
    }

    public StoreModel Read(int id)
    {
      return _db.Stores
        .Where(s => s.Id == id)
        .Include(s => s.Orders).ThenInclude(o => o.User)
        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
        .Include(s => s.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.PizzaToppings).ThenInclude(p => p.Topping)
        .SingleOrDefault();
    }

    public List<StoreModel> ReadStores()
    {
      return _db.Stores.ToList();
    }

    public bool ReadOrders(int storeId)
    {
      if (_db.Orders.FirstOrDefault(o => o.Store.Id == storeId) != null) return true;
      return false;
    }

    public void DeleteOldestOrder(int storeId)
    {
      OrderModel order = _db.Orders
        .Where(o => o.Store.Id == storeId)
        .Include(o => o.Pizzas).ThenInclude(p =>p.PizzaToppings)
        .FirstOrDefault();

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

      _db.Orders.Attach(order);
      _db.Orders.Remove(order);
      _db.SaveChanges();
    }
  }
}