using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _context;
        public CategoryService(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<List<Category>> ListCategoriesAsync()
        {
            try
            {
                var categories = await _context.CategoryRepository.GetItem().Take(5).ToListAsync();
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + ex.Message);
            }
        }
    }
}
