using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Mappers;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Mapper;
public class IngredientMapper : IMapper<Ingredient, IngredientDTO>
{
    public IngredientDTO ToDTO(Ingredient model)
    {
        return new IngredientDTO(model.Id, model.Name);
    }

    public List<IngredientDTO> ToDTO(List<Ingredient> models)
    {
        List<IngredientDTO> ingredientDTOs = new();
        foreach(Ingredient ingredient in models)
        {
            ingredientDTOs.Add(new IngredientDTO(ingredient.Id, ingredient.Name));
        }
        return ingredientDTOs;
    }
}