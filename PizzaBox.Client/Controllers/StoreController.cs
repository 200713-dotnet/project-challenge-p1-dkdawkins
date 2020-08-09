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
    [ValidateAntiForgeryToken]
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult WelcomeRedirect()
    {
      StoreHomeViewModel storeHomeViewModel = new StoreHomeViewModel()
      {
        Store = _repo.Read((int)TempData.Peek("StoreId"))
      };

      return View("Welcome", storeHomeViewModel);
    }

    [HttpPost]
    public IActionResult Orders(StoreHomeViewModel storeHomeViewModel)
    {
      StoreOrdersViewModel storeOrdersViewModel = new StoreOrdersViewModel()
      {
        Store = _repo.Read((int)TempData.Peek("StoreId")),
        UserName = storeHomeViewModel.Name
      };
      return View(storeOrdersViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteOrder()
    {
      return View();
    }
  }
}