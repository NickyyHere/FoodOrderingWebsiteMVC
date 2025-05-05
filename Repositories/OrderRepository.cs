using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class OrderRepository : IOrderRepository
{
    public readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id) ?? throw new Exception("");
    }
    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }
}