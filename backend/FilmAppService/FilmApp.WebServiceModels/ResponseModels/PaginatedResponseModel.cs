namespace FilmApp.WebServiceModels.ResponseModels;


public class PaginatedResponseModel<T> where  T : class
{
    public List<T> Items { get; set; }
    public int TotalRecords { get; set; }
}