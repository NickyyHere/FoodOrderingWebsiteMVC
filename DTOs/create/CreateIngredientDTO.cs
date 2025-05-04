namespace FoodOrderingWebsiteMVC.Create.DTO;
public class CreateIngredientDTO
{
    public string Name { get; set; }
    public CreateIngredientDTO(string name)
    {
        Name = name;
    }
}