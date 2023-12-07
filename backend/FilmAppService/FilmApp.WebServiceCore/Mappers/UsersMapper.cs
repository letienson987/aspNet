using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.Interfaces;
using FilmApp.WebServiceModels.Interfaces;
using FilmApp.WebServiceModels.ResponseModels;

namespace FilmAppp.WebServiceCore.Mappers;

public interface IUsersMapper : IBaseMapper<UsersResponseModel, Users>
{

}

public class UsersMapper : IUsersMapper
{
    public UsersResponseModel MapEntityToResponseModel(Users entity)
        => new()
        {
            Id = entity.Id,
            Username = entity.Username
        };


    public PaginatedResponseModel<UsersResponseModel> MapListEntityToPaginatedResponseModel(List<Users> entities, int totalRecords)
        => new()
        {
            TotalRecords = totalRecords,
            Items = entities.Select(MapEntityToResponseModel).ToList()
        };
}