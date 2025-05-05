using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class RestaurantRepository : IRestaurantRepository
{
    private readonly AppDbContext _context;
    public RestaurantRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
    }

    public async Task DeleteAsync(Restaurant restaurant)
    {
        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Restaurant>> GetAllAsync()
    {
        return await _context.Restaurants.ToListAsync();
    }

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        return await _context.Restaurants.FindAsync(id) ?? throw new Exception("");
    }

    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }
}