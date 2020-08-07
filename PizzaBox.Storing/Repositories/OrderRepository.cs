namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private PizzaBoxDbContext _db;

    public OrderRepository(PizzaBoxDbContext pizzaBoxDbContext)
    {
      _db = pizzaBoxDbContext;
    }
  }
}