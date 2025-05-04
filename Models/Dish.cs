namespace FoodOrderingWebsiteMVC.Models;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int RestaurantID { get; set;}
    public Restaurant Restaurant { get; set; }
    public ICollection<DishIngredient> Ingredients { get; set; } = new List<DishIngredient>();
    public ICollection<OrderDish> Orders { get; set; } = new List<OrderDish>();
    public Dish(string name, double price, Restaurant restaurant, ICollection<DishIngredient> ingredients)
    {
        Name = name;
        Price = price;
        Restaurant = restaurant;
        RestaurantID = restaurant.Id;
        Ingredients = ingredients;
    }
    public Dish()
    {
        Name = string.Empty;
        Restaurant = new();
    }
}