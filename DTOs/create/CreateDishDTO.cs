namespace FoodOrderingWebsiteMVC.Create.DTO;
public class CreateDishDTO
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int RestaurantId { get; set; }
    public List<int> IngredientIDs { get; set; }
    public CreateDishDTO(string name, double price, int restaurantId, List<int> ingredientIds)
    {
        Name = name;
        Price = price;
        RestaurantId = restaurantId;
        IngredientIDs = ingredientIds;
    }
}