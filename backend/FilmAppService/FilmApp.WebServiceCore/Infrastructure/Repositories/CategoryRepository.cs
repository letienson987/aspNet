using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Entities;

namespace FilmApp.WebServiceCore.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
}

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}