using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IRestaurantRepository
{
    public Task<Restaurant> GetByIdAsync(int id);
    public Task<List<Restaurant>> GetAllAsync();
    public Task AddAsync(Restaurant restaurant);
    public Task DeleteAsync(Restaurant restaurant);
    public Task UpdateAsync();
}