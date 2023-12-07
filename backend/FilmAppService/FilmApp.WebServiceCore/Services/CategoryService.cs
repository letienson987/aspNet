using FilmApp.WebServiceCore.Helpers;
using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.UnitOfWork;
using FilmApp.WebServiceCore.Interfaces;
using FilmApp.WebServiceCore.Repositories;
using FilmApp.WebServiceCore.Validation;
using FilmApp.WebServiceModels.RequestModels;
using FilmApp.WebServiceModels.ResponseModels;
using FilmAppp.WebServiceCore.Mappers;

namespace FilmApp.WebServiceCore.Services;

public interface ICategoryService : IBaseService<CategoryRequestModel, CategoryResponseModel>
{
    
}
public class CategoryService : ICategoryService
{
    // private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _unitOfWork;
    private readonly ICategoryMapper _mapper;
    private readonly IServiceValidation _validation;

    public CategoryService(
        ICategoryRepository unitOfWork,
        ICategoryMapper mapper,
        IServiceValidation validation)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validation = validation;
    }
    public async Task CreateAsync(CategoryRequestModel item)
    {
        try
        {
            var entityFound = await _unitOfWork
                .FindAsync(x => x.Name==item.Name);
            _validation.ItemFoundConflictNameWillThrowErr(entityFound);
        
            await _unitOfWork.CreateAsync(
                new Category
                {
                    Name = item.Name
                }
            );
            // await  _unitOfWork.SaveChangesAsync();
            
        } catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateAsync(CategoryRequestModel item, int id)
    {
        try
        {
            var entity = await _unitOfWork.FindAsync(x => x.Id == id);
            _validation.ItemNotFoundWillThrowErr(entity);
        
            var entityFound = await _unitOfWork
                .FindAsync(x => x.Name==item.Name);
            _validation.ItemFoundConflictNameWillThrowErr(entityFound);

            await _unitOfWork.UpdateAsync(
                new Category
                {
                    Id = entity.Id,
                    Name = item.Name
                }
            );
            // await  _unitOfWork.SaveChangesAsync();
            
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

    public async Task<CategoryResponseModel> GetByIdAsync(int id)
    {
        var result =  await _unitOfWork.GetByIdAsync(id);
        _validation.ItemNotFoundWillThrowErr(result);
        
        return _mapper.MapEntityToResponseModel(result);
    }

    public async Task<PaginatedResponseModel<CategoryResponseModel>> GetAllAsync(int page, int itemsPerPage)
    {
        var (offset, limit) = PaginationHelper.CalculatePagination(page, itemsPerPage);

        var result = await _unitOfWork.GetAllAsync(offset, limit);
        
        var totalRecords = await _unitOfWork.GetTotalRecordsAsync();
        
        return  _mapper.MapListEntityToPaginatedResponseModel(result, totalRecords);
    }
}