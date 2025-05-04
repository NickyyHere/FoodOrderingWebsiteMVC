using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Interfaces.Reposiories;
public interface IIngredientRepository
{
    public Task<Ingredient> GetByIdAsync(int id);
    public Task<List<Ingredient>> GetAllAsync();
    public Task AddAsync(CreateIngredientDTO dto);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, CreateIngredientDTO dto);
}