using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Factories;
public class IngredientFactory
{
    public Ingredient Build(CreateIngredientDTO createIngredientDTO)
    {
        return new Ingredient(createIngredientDTO.Name);
    }
}