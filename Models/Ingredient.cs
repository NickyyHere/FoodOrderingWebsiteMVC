namespace FoodOrderingWebsiteMVC.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<DishIngredient> Dishes { get; set;} = new List<DishIngredient>();

    public Ingredient(string name)
    {
        Name = name;
    }
    public Ingredient()
    {
        Name = string.Empty;
    }
}