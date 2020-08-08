using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class UserController : Controller
  {
    private readonly UserRepository _repo;

    public UserController(PizzaBoxDbContext dbContext)
    {
      _repo = new UserRepository(dbContext);
    }

    public IActionResult Login()
    {
      UserLoginViewModel userLoginViewModel = new UserLoginViewModel()
      {
        Stores = _repo.ReadStores()
      };
      
      return View(userLoginViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Welcome(UserLoginViewModel userLoginViewModel)
    {
      
      if (ModelState.IsValid) 
      {
        //Add user to database if they don't already exist
        if (_repo.Read(userLoginViewModel.Name) == null)
        {
          _repo.Create(userLoginViewModel.Name);
        }

        //Populate ViewModel
        UserHomeViewModel userHomeViewModel = new UserHomeViewModel()
        {
          User = _repo.Read(userLoginViewModel.Name),
          Store = _repo.ReadStore(userLoginViewModel.Store)
        };

        //Save IDs for later reference
        TempData["UserId"] = userHomeViewModel.User.Id;
        TempData["StoreId"] = userHomeViewModel.Store.Id;
        return View(userHomeViewModel);
      }

      userLoginViewModel.Stores = _repo.ReadStores();
      return View("Login", userLoginViewModel);
    }

    [HttpGet]
    public IActionResult History()
    {
      UserHistoryViewModel userHistoryViewModel = new UserHistoryViewModel()
      {
        User = _repo.Read((int)TempData.Peek("UserId"))
      };

      return View(userHistoryViewModel);  //Needs testing
    }
  }
}