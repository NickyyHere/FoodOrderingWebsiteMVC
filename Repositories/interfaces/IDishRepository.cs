using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IDishRepository
{
    public Task<Dish> GetByIdAsync(int id);
    public Task<List<Dish>> GetAllAsync();
    public Task AddAsync(CreateDishDTO dto);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, CreateDishDTO dto);
}