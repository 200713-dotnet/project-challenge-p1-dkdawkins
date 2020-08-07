using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class StoreController : Controller
  {
    private readonly StoreRepository _repo;

    public StoreController(PizzaBoxDbContext dbContext)
    {
      _repo = new StoreRepository(dbContext);
    }

    public IActionResult Login()
    {
      StoreViewModel storeViewModel = new StoreViewModel();
      storeViewModel.Stores = _repo.GetStores();
      return View(storeViewModel);
    }

    [HttpPost]
    public IActionResult Welcome(StoreViewModel storeViewModel)
    {
      if (ModelState.IsValid) 
      {
        return View();
      }

      storeViewModel.Stores = _repo.GetStores();
      return View("Login", storeViewModel);
    }
  }
}