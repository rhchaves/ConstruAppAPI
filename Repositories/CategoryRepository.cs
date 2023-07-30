using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ModelContext context) : base(context) { }

        public async Task<Category> GetActiveByIdAsync(int id)
        {
            return await GetItemByIdAsync(p => p.CategoryId == id && p.DeletedRegister == null && p.Status == 1);
        }

        public async Task<Category> GetActiveDesactiveByIdAsync(int id)
        {
            return await GetItemByIdAsync(p => p.CategoryId == id && p.DeletedRegister == null);
        }

        public async Task<Category> GetAnyCategoryByIdAsync(int id)
        {
            return await GetItemByIdAsync(p => p.CategoryId == id);
        }

        public async Task<List<Category>> ListCategoriesByNameAsync(int intQtdProducts, bool blnOrderDesc)
        {
            var query = GetItem().Where(p => p.DeletedRegister == null && p.Status == 1);

            if (blnOrderDesc)
                query = query.OrderByDescending(p => p.Label);
            else
                query = query.OrderBy(p => p.Label);

            return await query.Take(intQtdProducts).ToListAsync();
        }

        public async Task<PagedList<Category>> GetCategoriesByPagesAsync(QueryStringParameters itemParameters)
        {
            return await PagedList<Category>.ToPagedListAsync(GetItem().Where(p => p.Status == 1 && p.DeletedRegister == null).OrderBy(p => p.Name), itemParameters.PageNumber, itemParameters.PageSize);
        }

        public async Task<IEnumerable<Category>> GetCategoriesProductsAsync()
        {
            return await GetItem().Where(p => p.Status == 1 && p.DeletedRegister == null).Include(x => x.Products).ToListAsync();
        }

        public async Task<List<Category>> FindCategoryAsync(string name)
        {
            return await GetItem().Where(p => p.Label.ToUpper().Contains(name.ToUpper()) && p.Status == 1 && p.DeletedRegister == null).ToListAsync();
        }

    }
}
