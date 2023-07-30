using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConstruAppAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            try
            {
                List<CategoryDTO> categories = await _categoryService.ListAllCategoriesAsync();
                if (categories == null || categories.Count() == 0)
                    return NotFound("Não foi encontrado nenhuma categoria");
                return Ok(categories);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Categories/ID
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            try
            {
                CategoryDTO category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                    return NotFound("Não foi encontrado a categoria");
                return Ok(category);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Categories/Page  - traz os dados separados por página
        [HttpGet("pages")]
        public async Task<IActionResult> GetCategoriesByPagesAsync([FromQuery] QueryStringParameters itemsParameters)
        {
            try
            {
                (List<CategoryDTO> categories, object metadata) = await _categoryService.GetCategoriesByPagesAsync(itemsParameters);

                if (categories == null || categories.Count() == 0 || metadata == null)
                    return NotFound("Não foi encontrado nenhuma categoria");

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(categories);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Categories/find  - traz os dados separados por página
        [HttpGet("find")]
        public async Task<IActionResult> FindCategoryAsync(string name)
        {
            try
            {
                List<CategoryDTO> categories = await _categoryService.FindCategoryAsync(name);

                if (categories == null || categories.Count == 0)
                    return NotFound("Não foi encontrado nenhuma categoria");

                return Ok(categories);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        //---------------- Funções Administrativas ----------------//

        // adicionar restrição para admin - master, product e geral
        // GET: api/Categories/admin
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllCategoriesAdminAsync()
        {
            try
            {
                List<Category> categories = await _categoryService.ListAllCategoriesAdminAsync();
                if (categories == null || categories.Count() == 0)
                    return NotFound("Não foi encontrado nenhuma categoria");
                return Ok(categories);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> InsertCategoryAsync([FromBody] CategoryDTO categoryDto)
        {
            try
            {
                CategoryDTO result = await _categoryService.InsertCategoryAsync(categoryDto);

                if (result == null)
                    return BadRequest("Não foi possível criar a categoria");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // PUT: api/Categories/ID
        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryDTO categoryDto)
        {
            try
            {
                CategoryDTO result = await _categoryService.UpdateCategoryAsync(id, categoryDto);

                if (result == null)
                    return BadRequest("Não foi possível editar a categoria");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // PUT: api/Categories/ativar/ID
        [HttpPut("ativar{id:int:min(1)}")]
        public async Task<IActionResult> ActivateDeactivateCategoryAsync(int id)
        {
            try
            {
                CategoryDTO result = await _categoryService.ActivateDeactivateCategoryAsync(id);

                if (result == null)
                    return BadRequest("Não foi possível ativar/desativar a categoria");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // DELETE: api/Categories/ID
        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                CategoryDTO result = await _categoryService.DeleteCategoryAsync(id);

                if (result == null)
                    return BadRequest("Não foi encontrado a categoria");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}
