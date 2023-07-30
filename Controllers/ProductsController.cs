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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet("sales {intQtdProducts:int:min(1)}")]
        public async Task<IActionResult> GetProductsBySalesAsync(int intQtdProducts, bool blnOrderDesc)
        {
            try
            {
                List<ProductDTO> products = await _productService.ListProductsBySalesAsync(intQtdProducts, blnOrderDesc);
                if (products == null || products.Count() == 0)
                    return NotFound("Não foi encontrado nenhum produto");
                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Products
        [HttpGet("price {intQtdProducts:int:min(1)}")]
        public async Task<IActionResult> GetProductsByPriceAsync(int intQtdProducts, bool blnOrderDesc)
        {
            try
            {
                List<ProductDTO> products = await _productService.ListProductsByPriceAsync(intQtdProducts, blnOrderDesc);
                if (products == null || products.Count() == 0)
                    return NotFound("Não foi encontrado nenhum produto");
                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Products
        [HttpGet("name {intQtdProducts:int:min(1)}")]
        public async Task<IActionResult> GetProductsByNameAsync(int intQtdProducts, bool blnOrderDesc)
        {
            try
            {
                List<ProductDTO> products = await _productService.ListProductsByNameAsync(intQtdProducts, blnOrderDesc);
                if (products == null || products.Count() == 0)
                    return NotFound("Não foi encontrado nenhum produto");
                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Products/ID
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                ProductDTO product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                    return NotFound("Não foi encontrado o produto");
                return Ok(product);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Products/Page  - traz os dados separados por página
        [HttpGet("pages")]
        public async Task<IActionResult> GetProductsByPagesAsync([FromQuery] QueryStringParameters itemsParameters)
        {
            try
            {
                (List<ProductDTO> products, object metadata) = await _productService.GetProductsByPagesAsync(itemsParameters);

                if (products == null || products.Count() == 0 || metadata == null)
                    return NotFound("Não foi encontrado nenhum produto");

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // GET: api/Products/find  - traz os dados separados por página
        [HttpGet("find")]
        public async Task<IActionResult> FindProductAsync(string name)
        {
            try
            {
                List<ProductDTO> products = await _productService.FindProductAsync(name);

                if (products == null || products.Count == 0)
                    return NotFound("Não foi encontrado nenhum produto");

                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        //---------------- Funções Administrativas ----------------//

        // adicionar restrição para admin - master, product e geral
        // GET: api/Products/admin
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllProductsAdminAsync()
        {
            try
            {
                List<Product> products = await _productService.ListAllProductsAdminAsync();
                if (products == null || products.Count() == 0)
                    return NotFound("Não foi encontrado nenhum produto");
                return Ok(products);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> InsertProductAsync([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO result = await _productService.InsertProductAsync(productDTO);

                if (result == null)
                    return BadRequest("Não foi possível criar o produto");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // PUT: api/Products/ID
        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] ProductDTO productDto)
        {
            try
            {
                ProductDTO result = await _productService.UpdateProductAsync(id, productDto);

                if (result == null)
                    return BadRequest("Não foi possível editar o produto");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // PUT: api/Products/ativar/ID
        [HttpPut("ativar{id:int:min(1)}")]
        public async Task<IActionResult> ActivateDeactivateProductAsync(int id)
        {
            try
            {
                ProductDTO result = await _productService.ActivateDeactivateProductAsync(id);

                if (result == null)
                    return BadRequest("Não foi possível ativar/desativar o produto");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        // DELETE: api/Products/ID
        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                ProductDTO result = await _productService.DeleteProductAsync(id);

                if (result == null)
                    return BadRequest("Não foi encontrado o produto");

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
