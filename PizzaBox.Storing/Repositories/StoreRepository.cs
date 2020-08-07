using System.Collections.Generic;
using System.Linq;
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
    
    public List<StoreModel> GetStores()
    {
      return _db.Stores.ToList();
    }
  }
}