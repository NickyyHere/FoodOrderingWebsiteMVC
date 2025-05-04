namespace FoodOrderingWebsiteMVC.Models;

public class Order 
{
    public int Id { get; set; }
    public string City { get; set; }
    public string StreetAndNr { get; set; }
    public string PhoneNr { get; set; }
    public ICollection<OrderDish> Dishes { get; set; } = new List<OrderDish>();
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = new();
    public Order(string city, string streetAndNr, string phoneNr, ICollection<OrderDish> dishes, Restaurant restaurant)
    {
        City = city;
        StreetAndNr = streetAndNr;
        PhoneNr = phoneNr;
        Dishes = dishes;
        Restaurant = restaurant;
        RestaurantId = restaurant.Id;
    }
    public Order()
    {
        City = StreetAndNr = PhoneNr = string.Empty;
    }
}