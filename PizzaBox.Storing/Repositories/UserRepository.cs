using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private PizzaBoxDbContext _db;

    public UserRepository(PizzaBoxDbContext pizzaBoxDbContext)
    {
      _db = pizzaBoxDbContext;
    }

    public void Create(string name)
    {
      _db.Users.Add(new UserModel(){ Name = name });
      _db.SaveChanges();
    }

    //Find first user with given name
    public UserModel Read(string name)
    {
      return _db.Users
        .Where(u => u.Name == name)
        .Include(u => u.Orders).ThenInclude(o => o.Store)
        .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
        .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
        .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.PizzaToppings).ThenInclude(p => p.Topping)
        .SingleOrDefault();
    }

    //Find user by ID
    public UserModel Read(int id)
    {
      return _db.Users
        .Where(u => u.Id == id)
        .Include(u => u.Orders).ThenInclude(o => o.Store)
        .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Size)
        .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.Crust)
        .Include(u => u.Orders).ThenInclude(o => o.Pizzas).ThenInclude(p => p.PizzaToppings).ThenInclude(p => p.Topping)
        .SingleOrDefault();
    }

    public List<StoreModel> ReadStores()
    {
      return _db.Stores.ToList();
    }

    public StoreModel ReadStore(string storeName)
    {
      return _db.Stores.SingleOrDefault(s => s.Name == storeName);
    }

    public StoreModel ReadStore(int storeId)
    {
      return _db.Stores.SingleOrDefault(s => s.Id == storeId);
    }
  }
}