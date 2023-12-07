using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Entities;

namespace FilmApp.WebServiceCore.Repositories;

public interface ICommentsRepository : IBaseRepository<Comments>
{
}

public class CommentsRepository : BaseRepository<Comments>, ICommentsRepository
{
    public CommentsRepository(ApplicationDbContext context) : base(context)
    {
    }
}