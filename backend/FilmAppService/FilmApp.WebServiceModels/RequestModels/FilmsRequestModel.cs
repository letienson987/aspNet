namespace FilmApp.WebServiceModel.RequestModels;

public class FilmsRequestModel
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}