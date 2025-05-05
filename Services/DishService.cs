using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Mapper;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Services;
public class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly DishFactory _dishFactory;
    private readonly DishMapper _dishMapper = new();
    public DishService(IDishRepository dishRepository, IIngredientRepository ingredientRepository, DishFactory dishFactory)
    {
        _dishRepository = dishRepository;
        _ingredientRepository = ingredientRepository;
        _dishFactory = dishFactory;
    }

    public async Task AddDish(CreateDishDTO dto)
    {
        var dish = await _dishFactory.BuildAsync(dto);
        await _dishRepository.AddAsync(dish);
    }

    public async Task DeleteDish(int id)
    {
        var dish = await _dishRepository.GetByIdAsync(id);
        await _dishRepository.DeleteAsync(dish);
    }

    public async Task<DishDTO> GetDish(int id)
    {
        return _dishMapper.ToDTO(await _dishRepository.GetByIdAsync(id));
    }

    public async Task<List<DishDTO>> GetDishes()
    {
        return _dishMapper.ToDTO(await _dishRepository.GetAllAsync());
    }

    public async Task UpdateDish(int id, CreateDishDTO dto)
    {
        var dish = await _dishRepository.GetByIdAsync(id);
        dish.Name = dto.Name;
        dish.RestaurantID = dto.RestaurantId;
        dish.Price = dto.Price;
        var ingredients = await _ingredientRepository.GetByIdsAsync(dto.IngredientIDs);
        var existingIngredients = new HashSet<int>(dish.Ingredients.Select(di => di.IngredientId));
        var ingredientsToRemove = dish.Ingredients
            .Where(i => !dto.IngredientIDs.Contains(i.IngredientId))
            .ToList();
        var ingredientsToAdd = ingredients
            .Where(i => !existingIngredients.Contains(i.Id))
            .ToList();
        foreach(var ingredient in ingredientsToRemove)
        {
            dish.Ingredients.Remove(ingredient);
        }
        foreach(var ingredient in ingredientsToAdd)
        {
            dish.Ingredients.Add(new DishIngredient { IngredientId = ingredient.Id });
        }
        await _dishRepository.UpdateAsync();
    }
}