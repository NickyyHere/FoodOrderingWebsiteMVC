namespace FoodOrderingWebsiteMVC.DTO;
public class IngredientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IngredientDTO(int id, string name)
    {
        Id = id;
        Name = name;
    }
}