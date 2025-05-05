using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Mapper;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDishRepository _dishRepository;
    private readonly OrderFactory _orderFactory;
    private readonly OrderMapper _orderMapper = new();
    public OrderService(IOrderRepository orderRepository, IDishRepository dishRepository, OrderFactory orderFactory)
    {
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
        _orderFactory = orderFactory;
    }

    public async Task AddOrder(CreateOrderDTO dto)
    {
        var order = await _orderFactory.BuildAsync(dto);
        await _orderRepository.AddAsync(order);
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        await _orderRepository.DeleteAsync(order);
    }

    public async Task EditOrder(int id, CreateOrderDTO dto)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        order.City = dto.City;
        order.StreetAndNr = dto.StreetAndNr;
        order.PhoneNr = dto.PhoneNr;
        order.RestaurantId = dto.RestaurantID;
        var dishes = await _dishRepository.GetByIdsAsync(dto.DishIDs);
        var existingDishes = new HashSet<int>(order.Dishes.Select(d => d.DishId));
        var dishesToRemove = order.Dishes
            .Where(d => dto.DishIDs.Contains(d.DishId))
            .ToList();
        var dishesToAdd = dishes
            .Where(d => !existingDishes.Contains(d.Id))
            .ToList();
        foreach(var dish in dishesToRemove)
        {
            order.Dishes.Remove(dish);
        }
        foreach(var dish in dishesToAdd)
        {
            order.Dishes.Add(new OrderDish { DishId = dish.Id });
        }
        await _dishRepository.UpdateAsync();
    }

    public async Task<OrderDTO> GetOrder(int id)
    {
        return _orderMapper.ToDTO(await _orderRepository.GetByIdAsync(id));
    }

    public async Task<List<OrderDTO>> GetOrders()
    {
        return _orderMapper.ToDTO(await _orderRepository.GetAllAsync());
    }
}