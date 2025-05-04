namespace FoodOrderingWebsiteMVC.DTO;
public class DishDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RestaurantID { get; set; }
    public string RestaurantName { get; set; }
    public List<string> Ingredients { get; set; }
    public DishDTO(int id, string name, int restaurantId, string restaurantName, List<string> ingredients)
    {
        Id = id;
        Name = name;
        RestaurantID = restaurantId;
        RestaurantName = restaurantName;
        Ingredients = ingredients;
    }
}