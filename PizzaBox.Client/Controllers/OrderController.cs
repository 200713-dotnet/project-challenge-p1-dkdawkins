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

      TempData["OrderId"] = orderMenuViewModel.Order.Id;
      return View(orderMenuViewModel);
    }

    public IActionResult PresetMenu()
    {
      PresetPizzaViewModel presetPizzaViewModel = new PresetPizzaViewModel()
      {
        PresetPizzas = _repo.ReadPresetPizzas()
      };

      return View(presetPizzaViewModel);
    }

    public IActionResult CustomMenu()
    {
      CustomPizzaViewModel customPizzaViewModel = new CustomPizzaViewModel()
      {
        Crusts = _repo.ReadCrusts(),
        Sizes = _repo.ReadSizes(),
        Toppings = _repo.ReadToppings()
      };

      return View(customPizzaViewModel);
    }

    [HttpPost]
    public IActionResult AddPreset(PresetPizzaViewModel presetPizzaViewModel)
    {
      return View();  //TODO: create pizza and redirect to order menu
    }

    [HttpPost]
    public IActionResult AddCustom(CustomPizzaViewModel customPizzaViewModel)
    {
      return View();  //TODO: create pizza and redirect to order menu
    }
  }
}