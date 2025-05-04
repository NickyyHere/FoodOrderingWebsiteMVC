namespace FoodOrderingWebsiteMVC.Models;

public class DishIngredient
{
    public int DishId { get; set; }
    public Dish Dish { get; set; } = new();
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = new();
}