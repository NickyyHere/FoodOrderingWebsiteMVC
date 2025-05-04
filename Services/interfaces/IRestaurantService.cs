using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IRestaurantService
{
    public Task<List<RestaurantDTO>> GetRestaurants();
}