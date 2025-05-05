using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IDishRepository
{
    public Task<Dish> GetByIdAsync(int id);
    public Task<List<Dish>> GetByIdsAsync(List<int> ids);
    public Task<List<Dish>> GetAllAsync();
    public Task AddAsync(Dish dish);
    public Task DeleteAsync(Dish dish);
    public Task UpdateAsync();
}