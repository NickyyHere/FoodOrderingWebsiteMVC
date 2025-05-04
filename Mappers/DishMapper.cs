using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Mappers;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Mapper;
public class DishMapper : IMapper<Dish, DishDTO>
{
    public DishDTO ToDTO(Dish model)
    {
        List<string> ingredients = model.Ingredients.Select(i => i.Ingredient.Name).ToList();
        return new DishDTO(model.Id, model.Name, model.RestaurantID, model.Restaurant.Name, ingredients);
    }

    public List<DishDTO> ToDTO(List<Dish> models)
    {
        List<DishDTO> dishDTOs = new();
        foreach(Dish dish in models)
        {
            List<string> ingredients = dish.Ingredients.Select(i => i.Ingredient.Name).ToList();
            dishDTOs.Add(new DishDTO(dish.Id, dish.Name, dish.RestaurantID, dish.Restaurant.Name, ingredients));
        }
        return dishDTOs;
    }
}