using FoodOrderingWebsiteMVC.DTO;

namespace FoodOrderingWebsiteMVC.Interfaces.Services;
public interface IDishService
{
    public Task<List<DishDTO>> GetDishes();
}