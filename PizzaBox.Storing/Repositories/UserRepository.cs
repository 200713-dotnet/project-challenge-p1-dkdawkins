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

    public List<StoreModel> GetStores()
    {
      return _db.Stores.ToList();
    }
  }
}