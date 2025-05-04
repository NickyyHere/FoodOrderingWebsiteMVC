using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class RestaurantRepository : IRestaurantRepository
{
    private readonly AppDbContext _context;
    private readonly RestaurantFactory _restaurantFactory = new();
    public RestaurantRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(CreateRestaurantDTO dto)
    {
        await _context.Restaurants.AddAsync(_restaurantFactory.Build(dto));
    }

    public async Task DeleteAsync(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id) ?? throw new Exception("");
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

    public async Task UpdateAsync(int id, CreateRestaurantDTO dto)
    {
        var oldRestaurant = await _context.Restaurants.FindAsync(id) ?? throw new Exception("");
        var newRestaurant = _restaurantFactory.Build(dto);
        _context.Entry(oldRestaurant).CurrentValues.SetValues(newRestaurant);
        await _context.SaveChangesAsync();
    }
}