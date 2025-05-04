namespace FoodOrderingWebsiteMVC.Create.DTO;
public class CreateOrderDTO
{
    public string City { get; set; }
    public string StreetAndNr { get; set; }
    public string PhoneNr { get; set; }
    public List<int> DishIDs { get; set; }
    public int RestaurantID { get; set; }
    public CreateOrderDTO(string city, string streetAndNr, string phoneNr, List<int> dishIds, int restaurantId)
    {
        City = city;
        StreetAndNr = streetAndNr;
        PhoneNr = phoneNr;
        DishIDs = dishIds;
        RestaurantID = restaurantId;
    }
}