using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Mapper;

namespace FoodOrderingWebsiteMVC.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly OrderMapper _orderMapper = new();
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<List<OrderDTO>> GetOrders()
    {
        return _orderMapper.ToDTO(await _orderRepository.GetAllAsync());
    }
}