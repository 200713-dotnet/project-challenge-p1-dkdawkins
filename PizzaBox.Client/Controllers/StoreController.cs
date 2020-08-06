using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class StoreController : Controller
  {
    private readonly PizzaBoxDbContext _db;

    public StoreController(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public IActionResult Login()
    {
      return View(new StoreViewModel());
    }

    [HttpPost]
    public IActionResult Welcome(StoreViewModel storeViewModel)
    {
      if (ModelState.IsValid) 
      {
        return View();
      }

      return View("Login", storeViewModel);
    }
  }
}