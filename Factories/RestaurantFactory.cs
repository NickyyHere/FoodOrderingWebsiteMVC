using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Factories;
public class RestaurantFactory
{
    public Restaurant Build(CreateRestaurantDTO createRestaurantDTO)
    {
        return new Restaurant(createRestaurantDTO.Name);
    }
}