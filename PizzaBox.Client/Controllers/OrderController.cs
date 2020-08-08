using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  [Route("/[controller]/[action]")]
  public class OrderController : Controller
  {
    private readonly OrderRepository _repo;

    public OrderController(PizzaBoxDbContext dbContext)
    {
      _repo = new OrderRepository(dbContext);
    }

    public IActionResult Menu() //TODO: Make separate menu controller for preexisting order
    {
      OrderMenuViewModel orderMenuViewModel = new OrderMenuViewModel()
      {
        Order = _repo.Create((int)TempData.Peek("UserId"), (int)TempData.Peek("StoreId"))
      };
      return View(orderMenuViewModel);
    }
  }
}