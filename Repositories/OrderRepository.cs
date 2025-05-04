using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.dbcontext;
using FoodOrderingWebsiteMVC.Factories;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingWebsiteMVC.Repositories;
public class OrderRepository : IOrderRepository
{
    public readonly AppDbContext _context;
    public readonly OrderFactory _orderFactory;
    public OrderRepository(AppDbContext context, OrderFactory orderFactory)
    {
        _context = context;
        _orderFactory = orderFactory;
    }
    public async Task AddAsync(CreateOrderDTO dto)
    {
        await _context.Orders.AddAsync(await _orderFactory.BuildAsync(dto));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id) ?? throw new Exception("");
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

    public async Task UpdateAsync(int id, CreateOrderDTO dto)
    {
        var oldOrder = await _context.Orders.FindAsync(id) ?? throw new Exception("");
        var newOrder = await _orderFactory.BuildAsync(dto);
        _context.Entry(oldOrder).CurrentValues.SetValues(newOrder);
        await _context.SaveChangesAsync();
    }
}