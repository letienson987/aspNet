using FilmApp.WebServiceModels.ResponseModels;

namespace FilmApp.WebServiceModels.Interfaces;

public interface IBaseMapper<TResponse, TEntity>
    where TResponse : class 
    where TEntity : class
{
    TResponse MapEntityToResponseModel(TEntity entity);
    
    PaginatedResponseModel<TResponse> MapListEntityToPaginatedResponseModel(List<TEntity> entities, int totalRecords);
}