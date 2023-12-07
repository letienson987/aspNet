using FilmApp.WebServiceCore.Helpers;
using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.Interfaces;
using FilmApp.WebServiceCore.Repositories;
using FilmApp.WebServiceCore.Validation;
using FilmApp.WebServiceModel.RequestModels;
using FilmApp.WebServiceModels.ResponseModels;
using FilmAppp.WebServiceCore.Mappers;
using FilmApp.WebServiceModels.RequestModels;

namespace FilmApp.WebServiceCore.Services;

public interface IUsersService : IBaseService<UsersRequestModel, UsersResponseModel>
{

}
public class UsersService : IUsersService
{
    //private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly IUsersRepository _unitOfWork;
    private readonly IUsersMapper _mapper;
    private readonly IServiceValidation _validation;

    public UsersService(
        IUsersRepository unitOfWork,
        IUsersMapper mapper,
        IServiceValidation validation
        )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validation = validation;
    }

    public async Task CreateAsync(UsersRequestModel item)
    {
        try
        {
         
            await _unitOfWork.CreateAsync(
                new Users
                {
                    Username = item.Username,
                    Password = item.Password,
                    Email = item.Email


                }
            );
            // await  _unitOfWork.SaveChangesAsync();

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }


    //public async Task UpdateAsync(UsersRequestModel item, int id)
    //{
    //    try
    //    {
    //        var entity = await _unitOfWork.FindAsync(x => x.Id == id);
    //        _validation.ItemNotFoundWillThrowErr(entity);

    //        await _unitOfWork.UpdateAsync(
    //            new Users
    //            {
    //                Id = entity.Id,
    //                Username = item.Username,

    //            }
    //        );
    //        // await  _unitOfWork.SaveChangesAsync();

    //    }
    //    catch (Exception e)
    //    {
    //        throw new Exception(e.Message);
    //    }

    //}

    //public async Task DeleteAsync(int id)
    //{
    //    var result = await _unitOfWork.FindAsync(x => x.Id == id);
    //    _validation.ItemNotFoundWillThrowErr(result);

    //    await _unitOfWork.DeleteAsync(id);
    //}

    //public async Task<UsersResponseModel> GetByIdAsync(int id)
    //{
    //    var result = await _unitOfWork.GetByIdAsync(id);
    //    _validation.ItemNotFoundWillThrowErr(result);

    //    return _mapper.MapEntityToResponseModel(result);
    //}


    public async Task<PaginatedResponseModel<UsersResponseModel>> GetAllAsync(int page, int itemsPerPage)
    {
        var (offset, limit) = PaginationHelper.CalculatePagination(page, itemsPerPage);

        var result = await _unitOfWork.GetAllAsync(offset, limit);

        var totalRecords = await _unitOfWork.GetTotalRecordsAsync();

        return _mapper.MapListEntityToPaginatedResponseModel(result, totalRecords);
    }

    public Task<UsersResponseModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UsersRequestModel item, int id)
    {
        throw new NotImplementedException();
    }
}

