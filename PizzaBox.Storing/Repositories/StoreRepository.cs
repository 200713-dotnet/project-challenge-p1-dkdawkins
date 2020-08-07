namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    private PizzaBoxDbContext _db;

    public StoreRepository(PizzaBoxDbContext pizzaBoxDbContext)
    {
      _db = pizzaBoxDbContext;
    }
  }
}