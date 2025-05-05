using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IIngredientRepository
{
    public Task<Ingredient> GetByIdAsync(int id);
    public Task<List<Ingredient>> GetByIdsAsync(List<int> ids);
    public Task<List<Ingredient>> GetAllAsync();
    public Task AddAsync(Ingredient ingredient);
    public Task DeleteAsync(Ingredient ingredient);
    public Task UpdateAsync();
}