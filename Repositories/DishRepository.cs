using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class DishRepository : IDishRepository
{
    private readonly AppDbContext _context;
    private readonly DishFactory _dishFactory;
    public DishRepository(AppDbContext context, DishFactory dishFactory)
    {
        _context = context;
        _dishFactory = dishFactory;
    }
    public async Task AddAsync(CreateDishDTO dto)
    {
        await _context.Dishes.AddAsync(await _dishFactory.BuildAsync(dto));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dish = await _context.Dishes.FindAsync(id) ?? throw new Exception("");
        _context.Dishes.Remove(dish);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Dish>> GetAllAsync()
    {
        return await _context.Dishes.Include(d => d.Restaurant).ToListAsync();
    }

    public async Task<Dish> GetByIdAsync(int id)
    {
        return  await _context.Dishes.Include(d => d.Restaurant).FirstOrDefaultAsync(d => d.Id == id) ?? throw new Exception("");
    }

    public async Task UpdateAsync(int id, CreateDishDTO dto)
    {
        var oldDish = await _context.Dishes.FindAsync(id) ?? throw new Exception("");
        var newDish = await _dishFactory.BuildAsync(dto);
        _context.Entry(oldDish).CurrentValues.SetValues(newDish);
        await _context.SaveChangesAsync();
    }
}