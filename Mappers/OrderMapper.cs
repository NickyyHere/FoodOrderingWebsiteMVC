using FoodOrderingWebsiteMVC.DTO;
using FoodOrderingWebsiteMVC.Interfaces.Mappers;
using FoodOrderingWebsiteMVC.Models;

namespace FoodOrderingWebsiteMVC.Mapper;
public class OrderMapper : IMapper<Order, OrderDTO>
{
    public OrderDTO ToDTO(Order model)
    {
        Dictionary<string, int> dishes = new();
        foreach(OrderDish orderDish in model.Dishes)
        {
            dishes.Add(orderDish.Dish.Name, orderDish.Amount);
        }
        double price = model.Dishes.Sum(d => d.Dish.Price * d.Amount);
        return new OrderDTO(model.Id, model.City, model.StreetAndNr, model.PhoneNr, dishes, model.RestaurantId, model.Restaurant.Name, price);
    }

    public List<OrderDTO> ToDTO(List<Order> models)
    {
        List<OrderDTO> orderDTOs = new();
        foreach(Order order in models)
        {
            Dictionary<string, int> dishes = new();
            foreach(OrderDish orderDish in order.Dishes)
            {
                dishes.Add(orderDish.Dish.Name, orderDish.Amount);
            }
            double price = order.Dishes.Sum(d => d.Dish.Price * d.Amount);
            orderDTOs.Add(new OrderDTO(order.Id, order.City, order.StreetAndNr, order.PhoneNr, dishes, order.RestaurantId, order.Restaurant.Name, price));
        }
        return orderDTOs;
    }
}