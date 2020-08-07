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
      UserViewModel userViewModel = new UserViewModel();
      userViewModel.Stores = _repo.GetStores();
      return View(userViewModel);
    }

    [HttpPost]
    public IActionResult Welcome(UserViewModel userViewModel)
    {
      
      if (ModelState.IsValid) 
      {
        return View();
      }
      userViewModel.Stores = _repo.GetStores();
      return View("Login", userViewModel);
    }
  }
}