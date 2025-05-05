using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FoodOrderingWebsiteMVC.Models;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Create.DTO;

namespace FoodOrderingWebsiteMVC.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private readonly IDishService _dishService;
    public DishController(ILogger<DishController> logger, IDishService dishService)
    {
        _logger = logger;
        _dishService = dishService;
    }

    public async Task<IActionResult> Dishes()
    {
        ViewData["Title"] = "Dishes";
        return View(await _dishService.GetDishes());
    }
    public async Task<IActionResult> Details(int id)
    {
        var dish = await _dishService.GetDish(id);
        ViewData["Title"] = $"{dish.Name} - {dish.RestaurantName}";
        return View(dish);
    }
    public async Task<IActionResult> Edit(int id, CreateDishDTO dto)
    {
        await _dishService.UpdateDish(id, dto);
        return RedirectToAction("Details", new { id });
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _dishService.DeleteDish(id);
        return RedirectToAction("Index", "Home");
    }
}
