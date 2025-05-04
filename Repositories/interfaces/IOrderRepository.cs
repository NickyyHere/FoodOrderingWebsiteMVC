using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IOrderRepository
{
    public Task<Order> GetByIdAsync(int id);
    public Task<List<Order>> GetAllAsync();
    public Task AddAsync(CreateOrderDTO dto);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, CreateOrderDTO dto);
}