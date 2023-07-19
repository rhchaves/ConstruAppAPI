using ConstruAppAPI.Models;
namespace ConstruAppAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> ListCategoriesAsync();
    }
}
