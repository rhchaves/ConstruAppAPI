using AutoMapper;
using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
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

        public async Task<List<CategoryDTO>> ListCategoriesByNameAsync(int intQtdCategories, bool blnOrderDesc)
        {
            try
            {
                List<Category> categories = await _context.CategoryRepository.ListCategoriesByNameAsync(intQtdCategories, blnOrderDesc);
                List<CategoryDTO> categoriesDto = _mapper.Map<List<CategoryDTO>>(categories);
                return categoriesDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            try
            {
                Category category = await _context.CategoryRepository.GetActiveByIdAsync(id);
                CategoryDTO categoryDto = _mapper.Map<CategoryDTO>(category);
                return categoryDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao buscar a categoria: " + error.Message);
            }
        }

        public async Task<(List<CategoryDTO>, object)> GetCategoriesByPagesAsync(QueryStringParameters itemsParameters)
        {
            try
            {
                PagedList<Category> categories = await _context.CategoryRepository.GetCategoriesByPagesAsync(itemsParameters);

                object metadata = new
                {
                    categories.TotalCount,
                    categories.PageSize,
                    categories.CurrentPage,
                    categories.TotalPages,
                    categories.HasNext,
                    categories.HasPrevious
                };

                List<CategoryDTO> categoriesDto = _mapper.Map<List<CategoryDTO>>(categories);

                return (categoriesDto, metadata);
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao buscar a categoria: " + error.Message);
            }
        }

        public async Task<List<CategoryDTO>> FindCategoryAsync(string name)
        {
            try
            {
                List<Category> categories = await _context.CategoryRepository.FindCategoryAsync(name);
                List<CategoryDTO> categoryDto = _mapper.Map<List<CategoryDTO>>(categories);

                return categoryDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }
        //---------------- Funções Administrativas ----------------//

        public async Task<List<Category>> ListAllCategoriesAdminAsync()
        {
            try
            {
                List<Category> categories = await _context.CategoryRepository.GetItem().ToListAsync();
                return categories;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }

        public async Task<CategoryDTO> InsertCategoryAsync(CategoryDTO item)
        {
            try
            {
                Category category = _mapper.Map<Category>(item);

                _context.CategoryRepository.AddItem(category);
                await _context.CommitAsync();

                CategoryDTO categoryDto = _mapper.Map<CategoryDTO>(category);

                return categoryDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao inserir a categoria: " + error.Message);
            }
        }
        public async Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO item)
        {
            try
            {
                if (item.CategoryId != id) return null;

                Category existingCategory = await _context.CategoryRepository.GetActiveDesactiveByIdAsync(id);

                if (existingCategory == null) return null;

                existingCategory.ImageUri = item.ImageUri;
                existingCategory.UpdateRegister = DateTime.Now;

                _context.CategoryRepository.UpdateItem(existingCategory);
                await _context.CommitAsync();

                CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(existingCategory);

                return categoryDTO;
            }
            catch (DbUpdateConcurrencyException error)
            {
                throw new DbUpdateConcurrencyException("Ocorreu um erro ao editar a categoria: " + error.Message);
            }
        }

        public async Task<CategoryDTO> ActivateDeactivateCategoryAsync(int id)
        {
            try
            {
                Category category = await _context.CategoryRepository.GetActiveDesactiveByIdAsync(id);

                if (category == null) return null;

                if (category.Status == 0)
                    category.Status = 1;
                else
                    category.Status = 0;
                category.UpdateStatus = DateTime.Now;

                _context.CategoryRepository.UpdateItem(category);
                await _context.CommitAsync();

                CategoryDTO categoryDto = _mapper.Map<CategoryDTO>(category);

                return categoryDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao ativar/desativar a categoria: " + error.Message);
            }
        }

        public async Task<CategoryDTO> DeleteCategoryAsync(int id)
        {
            try
            {
                Category category = await _context.CategoryRepository.GetAnyCategoryByIdAsync(id);

                if (category == null || category.DeletedRegister != null) return null;

                category.Status = 0;
                category.DeletedRegister = DateTime.Now;

                _context.CategoryRepository.UpdateItem(category);
                await _context.CommitAsync();

                CategoryDTO categoryDto = _mapper.Map<CategoryDTO>(category);

                return categoryDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao deletar a categoria: " + error.Message);
            }
        }
    }
}
