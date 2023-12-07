using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceModels.Interfaces;
using FilmApp.WebServiceModels.ResponseModels;
using FilmApp.WebServiceModel.RequestModels;

namespace FilmApp.WebServiceCore.Mappers;

public interface IRatingsMapper : IBaseMapper<RatingsResponseModel, Ratings>
{
    Ratings MapEntityForUpdate(Ratings entity, RatingsRequestModel ratingsRequestModel, Films films, Users users);


}

public class RatingsMapper : IRatingsMapper
{
    public RatingsResponseModel MapEntityToResponseModel(Ratings entity)
        => new()
        {
            Id = entity.Id,
            //CategoryId = entity.Category == null ? 0 : entity.Category.Id,
            FilmId = entity.Film == null ? 0 : entity.Film.Id,
            UserId = entity.User == null ? 0 : entity.User.Id,
            Rating = entity.Rating,
            Timestamp = entity.Timestamp,

        };

    public PaginatedResponseModel<RatingsResponseModel> MapListEntityToPaginatedResponseModel(List<Ratings> entities, int totalRecords)
        => new()
        {
            TotalRecords = totalRecords,
            Items = entities.Select(MapEntityToResponseModel).ToList()
        };

    public Ratings MapEntityForUpdate(Ratings entity, RatingsRequestModel ratingsRequestModel, Films films, Users users)
    {
        entity.Rating = ratingsRequestModel.Rating;
        entity.User = users;
        entity.Film = films;
        return entity;
    }

   
}