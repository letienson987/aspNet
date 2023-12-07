namespace FilmApp.WebServiceModel.RequestModels;

public class CommentsRequestModel
{
    public int UserId { get; set; }
    //public int CategoryId { get; set; }
    public int FilmId { get; set; }
    public string Content { get; set; }

}