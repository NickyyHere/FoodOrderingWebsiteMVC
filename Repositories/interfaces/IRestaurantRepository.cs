using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IRestaurantRepository
{
    public Task<Restaurant> GetByIdAsync(int id);
    public Task<List<Restaurant>> GetAllAsync();
    public Task AddAsync(CreateRestaurantDTO dto);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, CreateRestaurantDTO dto);
}