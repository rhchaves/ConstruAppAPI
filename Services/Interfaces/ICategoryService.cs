using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;

namespace ConstruAppAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> ListCategoriesByNameAsync(int intQtdCategories, bool blnOrderDesc);
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<(List<CategoryDTO>, object)> GetCategoriesByPagesAsync(QueryStringParameters itemsParameters);
        Task<List<CategoryDTO>> FindCategoryAsync(string name);

        //---------------- Funções Administrativas ----------------//
        Task<List<Category>> ListAllCategoriesAdminAsync();
        Task<CategoryDTO> InsertCategoryAsync(CategoryDTO item);
        Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO item);
        Task<CategoryDTO> ActivateDeactivateCategoryAsync(int id);
        Task<CategoryDTO> DeleteCategoryAsync(int id);
    }
}
