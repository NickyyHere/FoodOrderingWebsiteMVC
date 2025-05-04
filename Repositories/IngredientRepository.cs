using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class IngredientRepository : IIngredientRepository
{
    private readonly AppDbContext _context;
    private readonly IngredientFactory _ingredientFactory = new();
    public IngredientRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(CreateIngredientDTO dto)
    {
        await _context.Ingredients.AddAsync(_ingredientFactory.Build(dto));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id) ?? throw new Exception("");
        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await _context.Ingredients.ToListAsync();
    }

    public async Task<Ingredient> GetByIdAsync(int id)
    {
        return await _context.Ingredients.FindAsync(id) ?? throw new Exception("");
    }

    public async Task UpdateAsync(int id, CreateIngredientDTO dto)
    {
        var oldIngredient = await _context.Ingredients.FindAsync(id) ?? throw new Exception("");
        var newIngredient = _ingredientFactory.Build(dto);
        _context.Entry(oldIngredient).CurrentValues.SetValues(newIngredient);
        await _context.SaveChangesAsync();
    }
}