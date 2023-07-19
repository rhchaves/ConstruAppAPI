using ConstruAppAPI.Context;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ConstruAppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private UserAdminRepository _userAdminRepository;
        private UserClientRepository _userClientRepository;
        private UserSellerRepository _userSellerRepository;

        public UnitOfWork(ConstruAppDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
            }
        }

        public IUserAdminRepository UserAdminRepository
        {
            get
            {
                return _userAdminRepository = _userAdminRepository ?? new UserAdminRepository(_context);
            }
        }
        public IUserClientRepository UserClientRepository
        {
            get
            {
                return _userClientRepository = _userClientRepository ?? new UserClientRepository(_context);
            }
        }

        public IUserSellerRepository UserSellerRepository
        {
            get
            {
                return _userSellerRepository = _userSellerRepository ?? new UserSellerRepository(_context);
            }
        }
        
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
