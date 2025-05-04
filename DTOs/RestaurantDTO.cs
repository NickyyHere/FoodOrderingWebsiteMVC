namespace FoodOrderingWebsiteMVC.DTO;
public class RestaurantDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public RestaurantDTO(int id, string name)
    {
        Id = id;
        Name = name;
    }
}