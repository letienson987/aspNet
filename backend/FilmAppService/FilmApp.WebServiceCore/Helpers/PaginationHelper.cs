// using BookStore.Models.RequestModels;

namespace FilmApp.WebServiceCore.Helpers;

public static class PaginationHelper
{
    public static (int, int) CalculatePagination(int page, int itemsPerPage)
    {
        if (itemsPerPage <= 0)
        {
            itemsPerPage = 50;
        }

        return (((page <= 0 ? 1 : page) - 1) * itemsPerPage, itemsPerPage);
    }
}