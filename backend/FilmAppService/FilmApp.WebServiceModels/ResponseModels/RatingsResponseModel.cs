namespace FilmApp.WebServiceModels.ResponseModels;

public class RatingsResponseModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FilmId { get; set; }
    public int Rating { get; set; }
    public DateTime Timestamp { get; set; }

}