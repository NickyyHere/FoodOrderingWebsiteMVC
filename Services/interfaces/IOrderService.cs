using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IOrderService
{
    public Task<List<OrderDTO>> GetOrders();
}