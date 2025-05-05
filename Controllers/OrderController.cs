using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingWebsiteMVC.Controllers;
public class OrderController : Controller
{
    private readonly ILogger _logger;
    private readonly IOrderService _orderService;
    public OrderController(ILogger logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }
    public async Task<IActionResult> Orders()
    {
        ViewData["Title"] = "All orders";
        var orders = await _orderService.GetOrders();
        return View(orders);
    }
    public async Task<IActionResult> Order(int id)
    {
        var order = await _orderService.GetOrder(id);
        ViewData["Title"] = $"Order from {order.RestaurantName}";
        return View(order);
    }
    public async Task<IActionResult> Edit(int id, CreateOrderDTO dto)
    {
        await _orderService.EditOrder(id, dto);
        return RedirectToAction("Order", new { id });
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _orderService.DeleteOrder(id);
        return RedirectToAction("Index", "Home");
    }
}