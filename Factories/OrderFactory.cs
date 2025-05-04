using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Factories;
public class OrderFactory
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IDishRepository _dishRepository;
    public OrderFactory(IRestaurantRepository restaurantRepository, IDishRepository dishRepository)
    {
        _restaurantRepository = restaurantRepository;
        _dishRepository = dishRepository;
    }
    public async Task<Order> BuildAsync(CreateOrderDTO createOrderDTO)
    {
        var restaurant = await _restaurantRepository.GetByIdAsync(createOrderDTO.RestaurantID);
        List<Dish> dishes = new();
        foreach(int id in createOrderDTO.DishIDs)
        {
            dishes.Add(await _dishRepository.GetByIdAsync(id));
        }
        return new Order(createOrderDTO.City, createOrderDTO.StreetAndNr, createOrderDTO.PhoneNr, dishes.Select(d => new OrderDish{ Dish = d }).ToList(), restaurant);
    }
}