using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IOrderRepository
{
    public Task<Order> GetByIdAsync(int id);
    public Task<List<Order>> GetAllAsync();
    public Task AddAsync(Order order);
    public Task DeleteAsync(Order order);
    public Task UpdateAsync();
}