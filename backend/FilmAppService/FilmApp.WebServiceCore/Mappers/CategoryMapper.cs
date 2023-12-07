using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.Interfaces;
using FilmApp.WebServiceModels.Interfaces;
using FilmApp.WebServiceModels.ResponseModels;

namespace FilmAppp.WebServiceCore.Mappers;

public interface ICategoryMapper: IBaseMapper<CategoryResponseModel, Category>
{
    
}

public class CategoryMapper : ICategoryMapper
{
    public CategoryResponseModel MapEntityToResponseModel(Category entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name
        };

    public PaginatedResponseModel<CategoryResponseModel> MapListEntityToPaginatedResponseModel(List<Category> entities, int totalRecords)
        => new()
        {
            TotalRecords = totalRecords,
            Items = entities.Select(MapEntityToResponseModel).ToList()
        };
}