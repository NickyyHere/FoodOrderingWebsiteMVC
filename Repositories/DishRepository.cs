using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class DishRepository : IDishRepository
{
    private readonly AppDbContext _context;
    public DishRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Dish dish)
    {
        await _context.Dishes.AddAsync(dish);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Dish dish)
    {
        _context.Dishes.Remove(dish);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Dish>> GetAllAsync()
    {
        return await _context.Dishes
            .Include(d => d.Restaurant)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Dish> GetByIdAsync(int id)
    {
        return await _context.Dishes
            .Include(d => d.Restaurant)
            .Include(d => d.Ingredients)
                .ThenInclude(dd => dd.Ingredient)
            .FirstOrDefaultAsync(d => d.Id == id)
            ?? throw new Exception("");
    }

    public async Task<List<Dish>> GetByIdsAsync(List<int> ids)
    {
        return await _context.Dishes
            .Where(d => ids.Contains(d.Id))
            .ToListAsync();
    }

    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }
}