using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Entities;

namespace FilmApp.WebServiceCore.Repositories;

public interface IUsersRepository : IBaseRepository<Users>
{
}

public class UsersRepository : BaseRepository<Users>, IUsersRepository
{
    public UsersRepository(ApplicationDbContext context) : base(context)
    {
    }
}