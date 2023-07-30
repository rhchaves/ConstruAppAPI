using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;

namespace ConstruAppAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> ListProductsBySalesAsync(int intQtdProducts, bool blnOrderDesc);
        Task<List<ProductDTO>> ListProductsByPriceAsync(int intQtdProducts, bool blnOrderDesc);
        Task<List<ProductDTO>> ListProductsByNameAsync(int intQtdProducts, bool blnOrderDesc);
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<(List<ProductDTO>, object)> GetProductsByPagesAsync(QueryStringParameters itemsParameters);
        Task<List<ProductDTO>> FindProductAsync(string name);

        //---------------- Funções Administrativas ----------------//
        Task<List<Product>> ListAllProductsAdminAsync();
        Task<ProductDTO> InsertProductAsync(ProductDTO item);
        Task<ProductDTO> UpdateProductAsync(int id, ProductDTO item);
        Task<ProductDTO> ActivateDeactivateProductAsync(int id);
        Task<ProductDTO> DeleteProductAsync(int id);
    }
}
