using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Mappers;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Mapper;
public class RestaurantMapper : IMapper<Restaurant, RestaurantDTO>
{
    public RestaurantDTO ToDTO(Restaurant model)
    {
        return new RestaurantDTO(model.Id, model.Name);
    }

    public List<RestaurantDTO> ToDTO(List<Restaurant> models)
    {
        List<RestaurantDTO> restaurantDTOs = new();
        foreach(Restaurant restaurant in models)
        {
            restaurantDTOs.Add(new RestaurantDTO(restaurant.Id, restaurant.Name));
        }
        return restaurantDTOs;
    }
}