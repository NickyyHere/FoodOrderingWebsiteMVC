using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IIngredientService
{
    public Task<List<IngredientDTO>> GetIngredients();
}