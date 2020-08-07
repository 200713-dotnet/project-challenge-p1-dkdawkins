using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class StoreController : Controller
  {
    private StoreRepository repo;

    public StoreController(PizzaBoxDbContext dbContext)
    {
      repo = new StoreRepository(dbContext);
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