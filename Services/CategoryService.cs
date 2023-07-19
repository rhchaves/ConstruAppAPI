using AutoMapper;
using ConstruAppAPI.DTOs;
using ConstruAppAPI.Repository.Interfaces;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> ListCategoriesAsync()
        {
            try
            {
                var categories = await _context.CategoryRepository.GetItem().Take(5).ToListAsync();
                var categoriesDto = _mapper.Map<List<CategoryDTO>>(categories);
                return categoriesDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + ex.Message);
            }
        }
    }
}
