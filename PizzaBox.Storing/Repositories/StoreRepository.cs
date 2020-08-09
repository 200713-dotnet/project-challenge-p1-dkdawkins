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
        .SingleOrDefault();
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
  }
}