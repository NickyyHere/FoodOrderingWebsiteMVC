using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Reposiories;
using FoodOrderingWebsiteMVC.Interfaces.Services;
using FoodOrderingWebsiteMVC.Mapper;

namespace FoodOrderingWebsiteMVC.Services;
public class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;
    private readonly DishMapper _dishMapper = new();
    public DishService(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }
    public async Task<List<DishDTO>> GetDishes()
    {
        return _dishMapper.ToDTO(await _dishRepository.GetAllAsync());
    }
}