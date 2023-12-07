using FilmApp.WebServiceCore.Constants;
using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmApp.WebServiceCore.Repositories;

public interface IFilmsRepository : IBaseRepository<Films>
{
    Task<Films> GetByIdIncludeFilmCategoryAsync(int id);

}

public class FilmsRepository : BaseRepository<Films>, IFilmsRepository
{
    public FilmsRepository(ApplicationDbContext context) : base(context)
    {

    }

    public virtual async Task<Films> GetByIdIncludeFilmCategoryAsync(int id)
    {
        try
        {
            return await _context.Film.Where(x => x.Id == id).Include(x => x.Category).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            throw new Exception(MessageConstants.BuildDbContextErrorMessage(
                nameof(Films), DbContextActionConstants.GetById, e.Message));
        }
    }
}