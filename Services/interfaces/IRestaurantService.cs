using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IRestaurantService
{
    public Task<List<RestaurantDTO>> GetRestaurants();
    public Task<RestaurantDTO> GetRestaurant(int id);
    public Task AddRestaurant(CreateRestaurantDTO dto);
    public Task EditRestaurant(int id, CreateRestaurantDTO dto);
    public Task DeleteRestaurant(int id);
}