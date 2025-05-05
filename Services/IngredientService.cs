using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Mapper;

namespace FoodOrderingWebsiteMVC.Services;
public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IngredientFactory _ingredientFactory = new();
    private readonly IngredientMapper _ingredientMapper = new();
    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<List<IngredientDTO>> GetIngredients()
    {
        return _ingredientMapper.ToDTO(await _ingredientRepository.GetAllAsync());
    }
    public async Task AddIngredient(CreateIngredientDTO dto)
    {
        var ingredient = _ingredientFactory.Build(dto);
        await _ingredientRepository.AddAsync(ingredient);
    }
    public async Task EditIngredient(int id, CreateIngredientDTO dto)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(id);
        ingredient.Name = dto.Name;
        await _ingredientRepository.UpdateAsync();
    }
} 