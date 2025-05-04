namespace FoodOrderingWebsiteMVC.Create.DTO;
public class CreateRestaurantDTO
{
    public string Name { get; set; }
    public CreateRestaurantDTO(string name)
    {
        Name = name;
    }
}