using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Factories;
public class DishFactory
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IIngredientRepository _ingredientRepository;
    public DishFactory(IRestaurantRepository restaurantRepository, IIngredientRepository ingredientRepository)
    {
        _restaurantRepository = restaurantRepository;
        _ingredientRepository = ingredientRepository;
    }
    public async Task<Dish> BuildAsync(CreateDishDTO createDishDTO)
    {
        var restaurant = await _restaurantRepository.GetByIdAsync(createDishDTO.RestaurantId);
        List<Ingredient> ingredients = new();
        foreach(int id in createDishDTO.IngredientIDs)
        {
            ingredients.Add(await _ingredientRepository.GetByIdAsync(id));
        }
        return new Dish(createDishDTO.Name, createDishDTO.Price, restaurant, ingredients.Select(i => new DishIngredient{ Ingredient = i }).ToList());
    }
}