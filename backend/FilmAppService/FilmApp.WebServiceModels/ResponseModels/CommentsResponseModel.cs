namespace FilmApp.WebServiceModels.ResponseModels;

public class CommentsResponseModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    //public int CategoryId { get; set; }
    public int FilmId { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }



}