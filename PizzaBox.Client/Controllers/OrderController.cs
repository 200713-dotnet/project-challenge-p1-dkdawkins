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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Menu()
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
    [ValidateAntiForgeryToken]
    public IActionResult AddPreset(PresetPizzaViewModel presetPizzaViewModel)
    {
      if (ModelState.IsValid)
      {
        //Check that the number of pizzas doesn't exceed 50
        if (_repo.Read((int)TempData.Peek("OrderId")).Pizzas.Count == 50)
        {
          ViewData["Status"] = "Cannot add pizza; number of pizzas in an order cannot exceed 50.";
        }

        //Check that price doesn't exceed $250


        //Create Pizza
        else 
        {
          _repo.CreatePresetPizza(presetPizzaViewModel.Name, (int)TempData.Peek("OrderId"));
          ViewData["Status"] = "Added new preset pizza!";
        }
        
        //Return to menu with new OrderMenu
        OrderMenuViewModel orderMenuViewModel = new OrderMenuViewModel()
        {
          Order = _repo.Read((int)TempData.Peek("OrderId")),
          Status = (string)ViewData["Status"]
        };

        return View("Menu", orderMenuViewModel);
      }

      presetPizzaViewModel.PresetPizzas = _repo.ReadPresetPizzas();
      return View("PresetMenu", presetPizzaViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddCustom(CustomPizzaViewModel customPizzaViewModel)
    {
      if (ModelState.IsValid)
      {
        
        if (_repo.Read((int)TempData.Peek("OrderId")).Pizzas.Count == 50)
        {
          ViewData["Status"] = "Cannot add pizza; number of pizzas in an order cannot exceed 50.";
        }
        
        //Create Pizza
        else
        {
          _repo.CreateCustomPizza(customPizzaViewModel.Crust, customPizzaViewModel.Size, customPizzaViewModel.SelectedToppings, (int)TempData.Peek("OrderId"));
          ViewData["Status"] = "Added new custom pizza!";
        }
        
        //Return to menu with new OrderMenu
        OrderMenuViewModel orderMenuViewModel = new OrderMenuViewModel()
        {
          Order = _repo.Read((int)TempData.Peek("OrderId")),
          Status = (string)ViewData["Status"]
        };

        return View("Menu", orderMenuViewModel);
      }
      
      customPizzaViewModel.Crusts = _repo.ReadCrusts();
      customPizzaViewModel.Sizes = _repo.ReadSizes();
      customPizzaViewModel.Toppings = _repo.ReadToppings();
      return View("CustomMenu", customPizzaViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
      _repo.DeletePizzas((int)TempData.Peek("OrderId"));
      ViewData["Status"] = "Pizzas removed from order!";

      OrderMenuViewModel orderMenuViewModel = new OrderMenuViewModel()
      {
        Order = _repo.Read((int)TempData.Peek("OrderId")),
        Status = (string)ViewData["Status"]
      };

      return View("Menu", orderMenuViewModel);
    }

    public IActionResult Checkout()
    {
      return View();
    }
  }
}