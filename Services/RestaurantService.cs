using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Mapper;

namespace FoodOrderingWebsiteMVC.Services;
public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly RestaurantMapper _restaurantMapper = new();
    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }
    public async Task<List<RestaurantDTO>> GetRestaurants()
    {
        return _restaurantMapper.ToDTO(await _restaurantRepository.GetAllAsync());
    }
}