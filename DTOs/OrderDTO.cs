namespace FoodOrderingWebsiteMVC.DTO;
public class OrderDTO
{
    public int Id { get; set; }
    public string City { get; set; }
    public string StreetAndNr { get; set; }
    public string PhoneNr { get; set; }
    public Dictionary<string, int> Dishes { get; set; }
    public int RestaurantID { get; set; }
    public string RestaurantName { get; set; }
    public double Price { get; set; }
    public OrderDTO(int id, string city, string streetAndNr, string phoneNr, Dictionary<string, int> dishes, int restaurantId, string restaurantName, double price)
    {
        Id = id;
        City = city;
        StreetAndNr = streetAndNr;
        PhoneNr = phoneNr;
        Dishes = dishes;
        RestaurantID = restaurantId;
        RestaurantName = restaurantName;
        Price = price;
    }
}