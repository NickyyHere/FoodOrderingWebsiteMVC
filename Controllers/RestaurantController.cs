using System.Data;
using System.Threading.Tasks;
using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingWebsiteMVC.Controllers;
public class RestaurantController : Controller
{
    private readonly ILogger<RestaurantController> _logger;
    private readonly IRestaurantService _restaurantService;
    public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService restaurantService)
    {
        _logger = logger;
        _restaurantService = restaurantService;
    }
    public async Task<IActionResult> Restaurants()
    {
        ViewData["Title"] = "Restaurants";
        return View(await _restaurantService.GetRestaurants());
    }
    public async Task<IActionResult> Restaurant(int id)
    {
        var restaurant = await _restaurantService.GetRestaurant(id);
        ViewData["Title"] = restaurant.Name;
        return View(restaurant);
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _restaurantService.DeleteRestaurant(id);
        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> Update(int id, CreateRestaurantDTO dto)
    {
        await _restaurantService.EditRestaurant(id, dto);
        return RedirectToAction("Restaurant", new { id });
    }
}