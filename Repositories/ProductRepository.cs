using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ModelContext context) : base(context) { }

        public async Task<Product> GetActiveByIdAsync(int id)
        {
            return await GetItemByIdAsync(p => p.ProductId == id && p.DeletedRegister == null && p.Status == 1);
        }

        public async Task<Product> GetActiveDesactiveByIdAsync(int id)
        {
            return await GetItemByIdAsync(p => p.ProductId == id && p.DeletedRegister == null);
        }

        public async Task<Product> GetAnyProductByIdAsync(int id)
        {
            return await GetItemByIdAsync(p => p.ProductId == id);
        }

        public async Task<List<Product>> ListProductsBySalesAsync(int intQtdProducts, bool blnOrderDesc)
        {
            var query = GetItem().Where(p => p.DeletedRegister == null && p.Status == 1);

            if (blnOrderDesc)
                query = query.OrderByDescending(p => p.SoldQtd).ThenBy(p => p.Name);
            else
                query = query.OrderBy(p => p.SoldQtd).ThenBy(p => p.Name);

            return await query.Take(intQtdProducts).ToListAsync();
        }

        public async Task<List<Product>> ListProductsByPriceAsync(int intQtdProducts, bool blnOrderDesc)
        {
            var query = GetItem().Where(p => p.DeletedRegister == null && p.Status == 1);

            if (blnOrderDesc)
                query = query.OrderByDescending(p => p.Price).ThenBy(p => p.Name);
            else
                query = query.OrderBy(p => p.Price).ThenBy(p => p.Name);

            return await query.Take(intQtdProducts).ToListAsync();
        }

        public async Task<List<Product>> ListProductsByNameAsync(int intQtdProducts, bool blnOrderDesc)
        {
            var query = GetItem().Where(p => p.DeletedRegister == null && p.Status == 1);

            if (blnOrderDesc)
                query = query.OrderByDescending(p => p.Name);
            else
                query = query.OrderBy(p => p.Name);

            return await query.Take(intQtdProducts).ToListAsync();
        }

        public async Task<PagedList<Product>> GetProductsByPagesAsync(QueryStringParameters itemParameters)
        {
            return await PagedList<Product>.ToPagedListAsync(GetItem().Where(p => p.Status == 1 && p.DeletedRegister == null).OrderBy(p => p.Name), itemParameters.PageNumber, itemParameters.PageSize);
        }

        public async Task<List<Product>> FindProductAsync(string name)
        {
            return await GetItem().Where(p => p.Label.ToUpper().Contains(name.ToUpper()) && p.Status == 1 && p.DeletedRegister == null).ToListAsync();
        }
    }
}
