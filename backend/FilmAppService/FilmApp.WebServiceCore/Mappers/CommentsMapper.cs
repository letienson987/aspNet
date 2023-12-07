using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceModels.Interfaces;
using FilmApp.WebServiceModels.ResponseModels;
using FilmApp.WebServiceModel.RequestModels;

namespace FilmApp.WebServiceCore.Mappers;

public interface ICommentsMapper : IBaseMapper<CommentsResponseModel, Comments>
{
    Comments MapEntityForUpdate(Comments entity, CommentsRequestModel commentsRequestModel,Films films, Users users);


}

public class CommentsMapper : ICommentsMapper
{
    public CommentsResponseModel MapEntityToResponseModel(Comments entity)
        => new()
        {
            Id = entity.Id,
            //CategoryId = entity.Category == null ? 0 : entity.Category.Id,
            FilmId = entity.Film == null ? 0 : entity.Film.Id,
            UserId = entity.User == null ? 0 : entity.User.Id,
            Content = entity.Content,
            Timestamp = entity.Timestamp,

        };

    public PaginatedResponseModel<CommentsResponseModel> MapListEntityToPaginatedResponseModel(List<Comments> entities, int totalRecords)
        => new()
        {
            TotalRecords = totalRecords,
            Items = entities.Select(MapEntityToResponseModel).ToList()
        };

    public Comments MapEntityForUpdate(Comments entity, CommentsRequestModel commentsRequestModel, Films films, Users users)
    {
        entity.Content = commentsRequestModel.Content;
        entity.User = users;
        entity.Film = films;
        return entity;
    }
}