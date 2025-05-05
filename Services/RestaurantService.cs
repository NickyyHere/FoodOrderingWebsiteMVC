using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Mapper;

namespace FoodOrderingWebsiteMVC.Services;
public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly RestaurantMapper _restaurantMapper = new();
    private readonly RestaurantFactory _restaurantFactory = new();
    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task AddRestaurant(CreateRestaurantDTO dto)
    {
        var restaurant = _restaurantFactory.Build(dto);
        await _restaurantRepository.AddAsync(restaurant);
    }

    public async Task DeleteRestaurant(int id)
    {
        var restaurant = await _restaurantRepository.GetByIdAsync(id);
        await _restaurantRepository.DeleteAsync(restaurant);
    }

    public async Task EditRestaurant(int id, CreateRestaurantDTO dto)
    {
        var restaurant = await _restaurantRepository.GetByIdAsync(id);
        restaurant.Name = dto.Name;
        await _restaurantRepository.UpdateAsync();
    }

    public async Task<RestaurantDTO> GetRestaurant(int id)
    {
        return _restaurantMapper.ToDTO(await _restaurantRepository.GetByIdAsync(id));
    }

    public async Task<List<RestaurantDTO>> GetRestaurants()
    {
        return _restaurantMapper.ToDTO(await _restaurantRepository.GetAllAsync());
    }
}