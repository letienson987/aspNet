using Microsoft.EntityFrameworkCore;

namespace FilmApp.WebServiceCore.Helpers;

public static class LinqHelper
{
    public static async Task<List<T>> ToPaginatedCollectionAsync<T>(this IQueryable<T> queryable, int offset, int limit) where T : class
    {
        return await queryable.Skip(offset)
            .Take(limit).ToListAsync();
    }
}