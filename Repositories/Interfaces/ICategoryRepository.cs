using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;

namespace ConstruAppAPI.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetActiveByIdAsync(int id);
        Task<Category> GetActiveDesactiveByIdAsync(int id);
        Task<Category> GetAnyCategoryByIdAsync(int id);
        Task<List<Category>> ListCategoriesByNameAsync(int intQtdCategories, bool blnOrderDesc);
        Task<PagedList<Category>> GetCategoriesByPagesAsync(QueryStringParameters itemsParameters);
        Task<IEnumerable<Category>> GetCategoriesProductsAsync();
        Task<List<Category>> FindCategoryAsync(string name);
    }
}
