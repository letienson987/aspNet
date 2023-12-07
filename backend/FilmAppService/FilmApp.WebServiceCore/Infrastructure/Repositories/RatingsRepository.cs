using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Entities;

namespace FilmApp.WebServiceCore.Repositories;

public interface IRatingsRepository : IBaseRepository<Ratings>
{
}

public class RatingsRepository : BaseRepository<Ratings>, IRatingsRepository
{
    public RatingsRepository(ApplicationDbContext context) : base(context)
    {
    }
}