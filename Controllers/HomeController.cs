using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FoodOrderingWebsiteMVC.Models;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using System.Threading.Tasks;

namespace FoodOrderingWebsiteMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDishService _dishService;
    private readonly IOrderService _orderService;
    private readonly IRestaurantService _restaurantService;
    private readonly IIngredientService _ingredientService;
    public HomeController(ILogger<HomeController> logger, IDishService dishService, IOrderService orderService, IRestaurantService restaurantService, IIngredientService ingredientService)
    {
        _logger = logger;
        _dishService = dishService;
        _orderService = orderService;
        _restaurantService = restaurantService;
        _ingredientService = ingredientService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Home Page";
        return View();
    }

    public async Task<IActionResult> Dishes()
    {
        ViewData["Title"] = "Dishes";
        return View(await _dishService.GetDishes());
    }

    public async Task<IActionResult> Restaurants()
    {
        ViewData["Title"] = "Restaurants";
        return View(await _restaurantService.GetRestaurants());
    }

    public IActionResult Order()
    {
        ViewData["Title"] = "Order";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
