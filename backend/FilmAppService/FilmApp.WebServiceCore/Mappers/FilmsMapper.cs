using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceModels.Interfaces;
using FilmApp.WebServiceModels.ResponseModels;
using FilmApp.WebServiceModel.RequestModels;

namespace FilmApp.WebServiceCore.Mappers;

public interface IFilmsMapper: IBaseMapper<FilmsResponseModel, Films>
{
    Films MapEntityForUpdate(Films entity, FilmsRequestModel filmsRequestModel, Category category);


}

public class FilmsMapper : IFilmsMapper
{
    public FilmsResponseModel MapEntityToResponseModel(Films entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Title,
            CategoryId = entity.Category == null ?0:entity.Category.Id,
            Description = entity.Description,
            Author = entity.Author,

        };

    public Films MapEntityForUpdate(Films entity, FilmsRequestModel filmsRequestModel, Category category)
        
        {
        entity.Title = filmsRequestModel.Name;
        entity.Category = category;
        entity.Description = filmsRequestModel.Description;
        entity.Author = filmsRequestModel.Author;
        return entity;
        }

    public PaginatedResponseModel<FilmsResponseModel> MapListEntityToPaginatedResponseModel(List<Films> entities, int totalRecords)
        => new()
        {
            TotalRecords = totalRecords,
            Items = entities.Select(MapEntityToResponseModel).ToList()
        };
}