using ConstruAppAPI.DTOs;
namespace ConstruAppAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> ListCategoriesAsync();
    }
}
