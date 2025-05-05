using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class IngredientRepository : IIngredientRepository
{
    private readonly AppDbContext _context;
    public IngredientRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Ingredient ingredient)
    {
        await _context.Ingredients.AddAsync(ingredient);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Ingredient ingredient)
    {
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
    public async Task<List<Ingredient>> GetByIdsAsync(List<int> ids)
    {
        return await _context.Ingredients.Where(i => ids.Contains(i.Id)).ToListAsync();
    }
    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }
}