using FilmApp.WebServiceCore.Helpers;
using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.Interfaces;
using FilmApp.WebServiceCore.Mappers;
using FilmApp.WebServiceCore.Repositories;
using FilmApp.WebServiceCore.Validation;
using FilmApp.WebServiceModel.RequestModels;
using FilmApp.WebServiceModels.ResponseModels;


namespace FilmApp.WebServiceCore.Services;

public interface IFilmsService : IBaseService<FilmsRequestModel, FilmsResponseModel>
{

}
public class FilmsService : IFilmsService
{
     //private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly IFilmsRepository _unitOfWork;
    private readonly IFilmsMapper _mapper;
    private readonly IServiceValidation _validation;
    private readonly ICategoryRepository _categoryUnitOfWork;

    public FilmsService(
        IFilmsRepository unitOfWork,
        IFilmsMapper mapper,
        IServiceValidation validation,
        ICategoryRepository categoryUnitOfWork
        )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validation = validation;
        _categoryUnitOfWork = categoryUnitOfWork;
    }

    public async Task CreateAsync(FilmsRequestModel item)
    {
        try
        {
            //var nameEntity = await _unitOfWork.FindAsync(x => x.Title == item.Name);
            //_validation.ItemFoundConflictNameWillThrowErr(nameEntity);

            var categoryEntity = await _categoryUnitOfWork.FindAsync(x => x.Id == item.CategoryId);
            _validation.ItemNotFoundWillThrowErr(categoryEntity);

         
            await _unitOfWork.CreateAsync(
                new Films
                {
                    Title = item.Name,
                    Description = item.Description,
                    Category = categoryEntity,
                    Author = item.Author,
                }
            );
            // await  _unitOfWork.SaveChangesAsync();

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


    public async Task UpdateAsync(FilmsRequestModel item, int id)
    {
        try
        {
            var entity = await _unitOfWork.FindAsync(x => x.Id == id);
            _validation.ItemNotFoundWillThrowErr(entity);
        
            var categoryEntity = await _categoryUnitOfWork.FindAsync(x => x.Id == item.CategoryId);
            _validation.ItemNotFoundWillThrowErr(categoryEntity);


            await _unitOfWork.UpdateAsync(
               _mapper.MapEntityForUpdate(entity, item, categoryEntity)
            ); 
            
        } catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public async Task DeleteAsync(int id)
    {
        var result =  await _unitOfWork.FindAsync(x => x.Id == id);
        _validation.ItemNotFoundWillThrowErr(result);
        
        await _unitOfWork.DeleteAsync(id);
        // await  _unitOfWork.SaveChangesAsync();
    }

    public async Task<FilmsResponseModel> GetByIdAsync(int id)
    {
        var result =  await _unitOfWork.GetByIdIncludeFilmCategoryAsync(id);
        _validation.ItemNotFoundWillThrowErr(result);


        return _mapper.MapEntityToResponseModel(result);
    }

    public async Task<PaginatedResponseModel<FilmsResponseModel>> GetAllAsync(int page, int itemsPerPage)
    {
        var (offset, limit) = PaginationHelper.CalculatePagination(page, itemsPerPage);

        var result = await _unitOfWork.GetAllAsync(offset, limit);

        var totalRecords = await _unitOfWork.GetTotalRecordsAsync();

        return  _mapper.MapListEntityToPaginatedResponseModel(result, totalRecords);
    }
}

