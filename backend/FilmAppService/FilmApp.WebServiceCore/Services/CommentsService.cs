using FilmApp.WebServiceCore.Helpers;
using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.Interfaces;
using FilmApp.WebServiceCore.Repositories;
using FilmApp.WebServiceCore.Validation;
using FilmApp.WebServiceModels.ResponseModels;
using FilmApp.WebServiceModel.RequestModels;
using FilmApp.WebServiceCore.Mappers;

namespace FilmApp.WebServiceCore.Services;

public interface ICommentsService : IBaseService<CommentsRequestModel, CommentsResponseModel>
{

}
public class CommentsService : ICommentsService
{
    // private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ICommentsRepository _unitOfWork;
    private readonly IUsersRepository _usersUnitOfWork;
    private readonly IFilmsRepository _filmsUnitOfWork;
    private readonly IServiceValidation _validation;
    private readonly ICommentsMapper _mapper;
    //private readonly ICategoryRepository _categoryUnitOfWork;

    public CommentsService(
        ICommentsRepository unitOfWork,
        IUsersRepository usersUnitOfWork,
        IServiceValidation validation,
        ICommentsMapper mapper,
        IFilmsRepository filmsUnitOfWork

        )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validation = validation;
        _usersUnitOfWork = usersUnitOfWork;
        _filmsUnitOfWork = filmsUnitOfWork;
    }
    public async Task CreateAsync(CommentsRequestModel item)
    {
        try
        {
            var userEntity = await _usersUnitOfWork.FindAsync(x => x.Id == item.UserId);
            _validation.ItemNotFoundWillThrowErr(userEntity);

            var filmEntity = await _filmsUnitOfWork.FindAsync(x => x.Id == item.FilmId);
            _validation.ItemNotFoundWillThrowErr(filmEntity);

            await _unitOfWork.CreateAsync(
                new Comments
                {
                    User = userEntity,
                    Film = filmEntity,
                    Content = item.Content,
                    Timestamp = DateTime.Now
        }
            );

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateAsync(CommentsRequestModel item, int id)
    {
        try
        {
            var entity = await _unitOfWork.FindAsync(x => x.Id == id);
            _validation.ItemNotFoundWillThrowErr(entity);


            await _unitOfWork.UpdateAsync(
                new Comments
                {
                    Id = entity.Id,
                    Content = item.Content,
                    //Timestamp = item.Timestamp
                }
            );
            // await  _unitOfWork.SaveChangesAsync();

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

    public async Task<CommentsResponseModel> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.GetByIdAsync(id);
        _validation.ItemNotFoundWillThrowErr(result);

        return _mapper.MapEntityToResponseModel(result);
    }

    public async Task<PaginatedResponseModel<CommentsResponseModel>> GetAllAsync(int page, int itemsPerPage)
    {
        var (offset, limit) = PaginationHelper.CalculatePagination(page, itemsPerPage);

        var result = await _unitOfWork.GetAllAsync(offset, limit);

        var totalRecords = await _unitOfWork.GetTotalRecordsAsync();

        return _mapper.MapListEntityToPaginatedResponseModel(result, totalRecords);
    }
}