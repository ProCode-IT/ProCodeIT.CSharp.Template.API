using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeIT.Template.DAL.Infra.Extension.Pagination
{
    public static class DataPagerExtension
    {
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit)
            where TModel : class
        {
            PagedModel<TModel> paged = new();

            page = Math.Max(page, 1);

            paged.CurrentPage = page;
            paged.PageSize = limit;

            paged.TotalItems = await query.CountAsync();

            int startRow = (page - 1) * limit;

            paged.Items = await query
                       .Skip(startRow)
                       .Take(limit)
                       .ToListAsync();

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }
    }
}
