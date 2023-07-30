using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;

namespace ConstruAppAPI.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<PagedList<Category>> GetCategoriesByPagesAsync(QueryStringParameters itemsParameters);
        Task<IEnumerable<Category>> GetCategoriesProductsAsync();
        Task<List<Category>> FindCategoryAsync(string name);
    }
}
