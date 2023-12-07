using FilmApp.WebServiceCore.Helpers;
using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.Interfaces;
using FilmApp.WebServiceCore.Repositories;
using FilmApp.WebServiceCore.Validation;
using FilmApp.WebServiceModels.ResponseModels;
using FilmApp.WebServiceModel.RequestModels;
using FilmApp.WebServiceCore.Mappers;

namespace FilmApp.WebServiceCore.Services;

public interface IRatingsService : IBaseService<RatingsRequestModel, RatingsResponseModel>
{

}
public class RatingsService : IRatingsService
{
    // private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly IRatingsRepository _unitOfWork;
    private readonly IUsersRepository _usersUnitOfWork;
    private readonly IFilmsRepository _filmsUnitOfWork;
    private readonly IServiceValidation _validation;
    private readonly IRatingsMapper _mapper;
    //private readonly ICategoryRepository _categoryUnitOfWork;

    public RatingsService(
        IRatingsRepository unitOfWork,
        IUsersRepository usersUnitOfWork,
        IServiceValidation validation,
        IRatingsMapper mapper,
        IFilmsRepository filmsUnitOfWork

        )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validation = validation;
        _usersUnitOfWork = usersUnitOfWork;
        _filmsUnitOfWork = filmsUnitOfWork;
    }
    public async Task CreateAsync(RatingsRequestModel item)
    {
        try
        {
            var userEntity = await _usersUnitOfWork.FindAsync(x => x.Id == item.UserId);
            _validation.ItemNotFoundWillThrowErr(userEntity);

            var filmEntity = await _filmsUnitOfWork.FindAsync(x => x.Id == item.FilmId);
            _validation.ItemNotFoundWillThrowErr(filmEntity);

            await _unitOfWork.CreateAsync(
                new Ratings
                {
                    User = userEntity,
                    Film = filmEntity,
                    Rating = item.Rating,
                    Timestamp = DateTime.Now
                }
            );

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateAsync(RatingsRequestModel item, int id)
    {
        try
        {
            var entity = await _unitOfWork.FindAsync(x => x.Id == id);
            _validation.ItemNotFoundWillThrowErr(entity);


            await _unitOfWork.UpdateAsync(
                new Ratings
                {
                    Id = entity.Id,
                    Rating = item.Rating,
                }
            );

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }

    public async Task DeleteAsync(int id)
    {
        var result = await _unitOfWork.FindAsync(x => x.Id == id);
        _validation.ItemNotFoundWillThrowErr(result);

        await _unitOfWork.DeleteAsync(id);
        // await  _unitOfWork.SaveChangesAsync();
    }

    public async Task<RatingsResponseModel> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.GetByIdAsync(id);
        _validation.ItemNotFoundWillThrowErr(result);

        return _mapper.MapEntityToResponseModel(result);
    }

    public async Task<PaginatedResponseModel<RatingsResponseModel>> GetAllAsync(int page, int itemsPerPage)
    {
        var (offset, limit) = PaginationHelper.CalculatePagination(page, itemsPerPage);

        var result = await _unitOfWork.GetAllAsync(offset, limit);

        var totalRecords = await _unitOfWork.GetTotalRecordsAsync();

        return _mapper.MapListEntityToPaginatedResponseModel(result, totalRecords);
    }
}