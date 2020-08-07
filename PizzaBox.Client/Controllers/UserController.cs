using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class UserController : Controller
  {
    private UserRepository repo;

    public UserController(PizzaBoxDbContext dbContext)
    {
      repo = new UserRepository(dbContext);
    }

    public IActionResult Login()
    {
      UserViewModel userViewModel = new UserViewModel();  //Should this be done here?
      userViewModel.Stores = repo.GetStores();
      return View(userViewModel);
    }

    [HttpPost]
    public IActionResult Welcome(UserViewModel userViewModel) //TODO: Fix data loss on bad validation
    {
      if (ModelState.IsValid) 
      {
        return View();
      }

      return View("Login", userViewModel);
    }
  }
}