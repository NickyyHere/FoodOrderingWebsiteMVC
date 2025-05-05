using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IOrderService
{
    public Task<List<OrderDTO>> GetOrders();
    public Task<OrderDTO> GetOrder(int id);
    public Task AddOrder(CreateOrderDTO dto);
    public Task EditOrder(int id, CreateOrderDTO dto);
    public Task DeleteOrder(int id);
}