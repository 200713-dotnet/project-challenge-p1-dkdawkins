using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class StartController : Controller
  {
    public IActionResult Home()
    {
      return View();
    }
  }
}