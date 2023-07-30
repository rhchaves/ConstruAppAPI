using AutoMapper;
using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> ListProductsBySalesAsync(int intQtdProducts, bool blnOrderDesc)
        {
            try
            {
                List<Product> products = await _context.ProductRepository.ListProductsBySalesAsync(intQtdProducts, blnOrderDesc);
                List<ProductDTO> productsDto = _mapper.Map<List<ProductDTO>>(products);
                return productsDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }

        public async Task<List<ProductDTO>> ListProductsByPriceAsync(int intQtdProducts, bool blnOrderDesc)
        {
            try
            {
                List<Product> products = await _context.ProductRepository.ListProductsByPriceAsync(intQtdProducts, blnOrderDesc);
                List<ProductDTO> productsDto = _mapper.Map<List<ProductDTO>>(products);
                return productsDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }

        public async Task<List<ProductDTO>> ListProductsByNameAsync(int intQtdProducts, bool blnOrderDesc)
        {
            try
            {
                List<Product> products = await _context.ProductRepository.ListProductsByNameAsync(intQtdProducts, blnOrderDesc);
                List<ProductDTO> productsDto = _mapper.Map<List<ProductDTO>>(products);
                return productsDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            try
            {
                Product product = await _context.ProductRepository.GetActiveByIdAsync(id);
                ProductDTO productDto = _mapper.Map<ProductDTO>(product);
                return productDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao buscar a categoria: " + error.Message);
            }
        }

        public async Task<(List<ProductDTO>, object)> GetProductsByPagesAsync(QueryStringParameters itemsParameters)
        {
            try
            {
                PagedList<Product> products = await _context.ProductRepository.GetProductsByPagesAsync(itemsParameters);

                object metadata = new
                {
                    products.TotalCount,
                    products.PageSize,
                    products.CurrentPage,
                    products.TotalPages,
                    products.HasNext,
                    products.HasPrevious
                };

                List<ProductDTO> productsDto = _mapper.Map<List<ProductDTO>>(products);

                return (productsDto, metadata);
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao buscar a categoria: " + error.Message);
            }
        }

        public async Task<List<ProductDTO>> FindProductAsync(string name)
        {
            try
            {
                List<Product> products = await _context.ProductRepository.FindProductAsync(name);
                List<ProductDTO> productsDto = _mapper.Map<List<ProductDTO>>(products);

                return productsDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }
        //---------------- Funções Administrativas ----------------//

        public async Task<List<Product>> ListAllProductsAdminAsync()
        {
            try
            {
                List<Product> products = await _context.ProductRepository.GetItem().ToListAsync();
                return products;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao listar as categorias: " + error.Message);
            }
        }

        public async Task<ProductDTO> InsertProductAsync(ProductDTO item)
        {
            try
            {
                Product product = _mapper.Map<Product>(item);

                _context.ProductRepository.AddItem(product);
                await _context.CommitAsync();

                ProductDTO productDto = _mapper.Map<ProductDTO>(product);

                return productDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao inserir a categoria: " + error.Message);
            }
        }
        public async Task<ProductDTO> UpdateProductAsync(int id, ProductDTO item)
        {
            try
            {
                if (item.ProductId != id) return null;

                Product existingProduct = await _context.ProductRepository.GetActiveDesactiveByIdAsync(id);

                if (existingProduct == null) return null;

                existingProduct.Label = item.Label;
                existingProduct.Description = item.Description;
                existingProduct.ImageUri = item.ImageUri;
                existingProduct.UpdateRegister = DateTime.Now;

                _context.ProductRepository.UpdateItem(existingProduct);
                await _context.CommitAsync();

                ProductDTO productDto = _mapper.Map<ProductDTO>(existingProduct);

                return productDto;
            }
            catch (DbUpdateConcurrencyException error)
            {
                throw new DbUpdateConcurrencyException("Ocorreu um erro ao editar a categoria: " + error.Message);
            }
        }

        public async Task<ProductDTO> ActivateDeactivateProductAsync(int id)
        {
            try
            {
                Product product = await _context.ProductRepository.GetActiveDesactiveByIdAsync(id);

                if (product == null) return null;

                if (product.Status == 0)
                    product.Status = 1;
                else
                    product.Status = 0;
                product.UpdateStatus = DateTime.Now;

                _context.ProductRepository.UpdateItem(product);
                await _context.CommitAsync();

                ProductDTO productDto = _mapper.Map<ProductDTO>(product);

                return productDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao ativar/desativar a categoria: " + error.Message);
            }
        }

        public async Task<ProductDTO> DeleteProductAsync(int id)
        {
            try
            {
                Product product = await _context.ProductRepository.GetAnyProductByIdAsync(id);

                if (product == null || product.DeletedRegister != null) return null;

                product.Status = 0;
                product.DeletedRegister = DateTime.Now;

                _context.ProductRepository.UpdateItem(product);
                await _context.CommitAsync();

                ProductDTO productDto = _mapper.Map<ProductDTO>(product);

                return productDto;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao deletar a categoria: " + error.Message);
            }
        }
    }
}
