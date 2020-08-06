using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class UserController : Controller
  {
    private readonly PizzaBoxDbContext _db;

    public UserController(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public IActionResult Login()
    {
      return View(new UserViewModel());
    }

    [HttpPost]
    public IActionResult Welcome(UserViewModel userViewModel)
    {
      if (ModelState.IsValid) 
      {
        return View();
      }

      return View("Login", userViewModel);
    }
  }
}