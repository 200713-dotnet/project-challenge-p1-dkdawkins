using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class StartController : Controller
  {
    private readonly PizzaBoxDbContext _db;

    public StartController(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public IActionResult Home()
    {
      return View();
    }
  }
}