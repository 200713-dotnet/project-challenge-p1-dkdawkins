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
      StoreLoginViewModel storeLoginViewModel = new StoreLoginViewModel();
      storeLoginViewModel.Stores = _repo.ReadStores();
      return View(storeLoginViewModel);
    }

    [HttpPost]
    public IActionResult Welcome(StoreLoginViewModel storeLoginViewModel)
    {
      if (ModelState.IsValid) 
      {
        StoreHomeViewModel storeHomeViewModel = new StoreHomeViewModel()
        {
          Store = _repo.Read(storeLoginViewModel.Name)
        };

        TempData["StoreId"] = storeHomeViewModel.Store.Id;
        return View(storeHomeViewModel);
      }

      storeLoginViewModel.Stores = _repo.ReadStores();
      return View("Login", storeLoginViewModel);
    }
  }
}