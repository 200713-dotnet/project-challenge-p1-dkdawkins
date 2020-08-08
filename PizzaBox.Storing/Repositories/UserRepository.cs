using System.Collections.Generic;
using System.Linq;
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
      return _db.Users.SingleOrDefault(u => u.Name == name);
    }

    //Find user by ID
    public UserModel Read(int id)
    {
      return _db.Users.SingleOrDefault(u => u.Id == id);
    }

    public List<StoreModel> ReadStores()
    {
      return _db.Stores.ToList();
    }

    public StoreModel ReadStore(string storeName)
    {
      return _db.Stores.SingleOrDefault(s => s.Name == storeName);
    }
  }
}