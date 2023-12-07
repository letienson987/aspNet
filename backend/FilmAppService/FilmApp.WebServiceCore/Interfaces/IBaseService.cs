using System.Linq.Expressions;
using FilmApp.WebServiceModels.ResponseModels;

namespace FilmApp.WebServiceCore.Interfaces;

public interface IBaseService<T, K> where T : class where K : class
{
    Task CreateAsync(T item);
    Task UpdateAsync(T item, int id);
    Task DeleteAsync(int id);
    Task<K> GetByIdAsync(int id);
    Task<PaginatedResponseModel<K>> GetAllAsync(int page, int itemsPerPage);
}