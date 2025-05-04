namespace FoodOrderingWebsiteMVC.Interfaces.Mappers;
public interface IMapper<MODEL, DTO>
{
    public DTO ToDTO(MODEL model);
    public List<DTO> ToDTO(List<MODEL> models);
}