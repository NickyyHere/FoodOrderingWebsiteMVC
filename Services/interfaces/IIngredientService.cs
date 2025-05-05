using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IIngredientService
{
    public Task<List<IngredientDTO>> GetIngredients();
    public Task AddIngredient(CreateIngredientDTO dto);
    public Task EditIngredient(int id, CreateIngredientDTO dto);
}