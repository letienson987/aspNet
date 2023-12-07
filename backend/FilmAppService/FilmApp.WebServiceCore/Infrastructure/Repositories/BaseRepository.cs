using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Constants;
//using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Helpers;

namespace FilmApp.WebServiceCore.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task CreateAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync(int offset, int limit);
    Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    Task<int> GetTotalRecordsAsync();
}

public class BaseRepository<T> where T :class
{
    protected readonly DbSet<T> DbSet;
    protected ApplicationDbContext _context;
    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }

    public async Task CreateAsync(T item)
    {
        try
        {
            await DbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(MessageConstants.BuildDbContextErrorMessage(
                nameof(T), DbContextActionConstants.Create, e.Message));
        }
    }

    public async Task UpdateAsync(T item)
    {
        try
        {
            DbSet.Update(item).State = EntityState.Modified;
            await Task.CompletedTask;
            await _context.SaveChangesAsync();

        }
        catch (Exception e)
        {
            throw new Exception(MessageConstants.BuildDbContextErrorMessage(
                nameof(T), DbContextActionConstants.Update, e.Message));
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var item = await DbSet.FindAsync(id);
            if (item is not null)
            {
                DbSet.Remove(item);
                await _context.SaveChangesAsync();

            }
            await Task.CompletedTask;
        }
        catch (Exception e)
        {
            throw new Exception(MessageConstants.BuildDbContextErrorMessage(
                nameof(T), DbContextActionConstants.Delete, e.Message));
        }
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        try
        {
            return await  DbSet.FindAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(MessageConstants.BuildDbContextErrorMessage(
                nameof(T), DbContextActionConstants.GetById, e.Message));
        }
    }

    public virtual async Task<List<T>> GetAllAsync(int offset, int limit)
    {
        try
        {
            return await DbSet
                .ToPaginatedCollectionAsync(offset, limit);
        }
        catch (Exception e)
        {
            throw new Exception(MessageConstants.BuildDbContextErrorMessage(
                nameof(T), DbContextActionConstants.GetAll, e.Message));
        }
    }

    public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await DbSet.Where(predicate).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            throw new Exception(MessageConstants.BuildDbContextErrorMessage(
                nameof(T), DbContextActionConstants.Find, e.Message));
        }
    }

    public async Task<int> GetTotalRecordsAsync()
    {
        return await DbSet.CountAsync();
    }
}