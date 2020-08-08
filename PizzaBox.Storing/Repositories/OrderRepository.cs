using System.Collections.Generic;
using System.Linq;
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