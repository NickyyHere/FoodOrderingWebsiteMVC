namespace FoodOrderingWebsiteMVC.Models;

public class OrderDish
{
    public int DishId { get; set; }
    public Dish Dish { get; set; } = new();
    public int OrderId { get; set; }
    public Order Order { get; set; } = new();
    public int Amount { get; set; }
}