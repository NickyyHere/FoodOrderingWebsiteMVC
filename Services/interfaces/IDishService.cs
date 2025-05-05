using FoodOrderingWebsiteMVC.Create.DTO;
using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IDishService
{
    public Task<List<DishDTO>> GetDishes();
    public Task<DishDTO> GetDish(int id);
    public Task UpdateDish(int id, CreateDishDTO dto);
    public Task DeleteDish(int id);
    public Task AddDish(CreateDishDTO dto);
}