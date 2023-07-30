using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;

namespace ConstruAppAPI.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetActiveByIdAsync(int id);
        Task<Product> GetActiveDesactiveByIdAsync(int id);
        Task<Product> GetAnyProductByIdAsync(int id);
        Task<List<Product>> ListProductsBySalesAsync(int intQtdProducts, bool blnOrderDesc);
        Task<List<Product>> ListProductsByPriceAsync(int intQtdProducts, bool blnOrderDesc);
        Task<List<Product>> ListProductsByNameAsync(int intQtdProducts, bool blnOrderDesc);
        Task<PagedList<Product>> GetProductsByPagesAsync(QueryStringParameters itemsParameters);
        Task<List<Product>> FindProductAsync(string name);
    }
}
