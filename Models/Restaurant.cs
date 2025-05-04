namespace FoodOrderingWebsiteMVC.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public Restaurant(string name)
    {
        Name = name;
    }
    public Restaurant()
    {
        Name = string.Empty;
    }
}