namespace FilmApp.WebServiceModel.RequestModels;

public class RatingsRequestModel
{
    public int UserId { get; set; }
    //public int CategoryId { get; set; }
    public int FilmId { get; set; }
    public int Rating { get; set; }

}