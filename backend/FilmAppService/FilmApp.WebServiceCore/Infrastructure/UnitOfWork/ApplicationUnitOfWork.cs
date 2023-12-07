using FilmApp.WebServiceCore.Constants;
using FilmApp.WebServiceCore.Database;
using FilmApp.WebServiceCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FilmApp.WebServiceCore.UnitOfWork;

public interface IApplicationUnitOfWork
{
    // public IFilmRepository FilmRepository { get; }
    // public IOrderRepository OrderRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    // public IBookRepository BookRepository { get; }
    // public ICartItemRepository CartItemRepository { get; }
    // public IShoppingCartRepository ShoppingCartRepository { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    void Rollback();
}
public class ApplicationUnitOfWork : IApplicationUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public ICategoryRepository CategoryRepository { get; }
    public ApplicationUnitOfWork()
    {
        CategoryRepository = new CategoryRepository(_context);
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public Task CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void Rollback()
    {
        throw new NotImplementedException();
    }
}