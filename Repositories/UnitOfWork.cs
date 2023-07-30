using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ModelContext _context;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private PurchaseOrderRepository _purchaseOrderRepository;
        private PurchaseOrderItemRepository _purchaseOrderItemRepository;
        private ShoppingCartRepository _shoppingCartRepository;
        private ShoppingCartItemRepository _shoppingCartItemRepository;
        private UserAdminRepository _userAdminRepository;
        private UserClientRepository _userClientRepository;
        private UserSellerRepository _userSellerRepository;

        public UnitOfWork(ModelContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context); }
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_context); }
        }

        public IPurchaseOrderRepository PurchaseOrderRepository
        {
            get { return _purchaseOrderRepository = _purchaseOrderRepository ?? new PurchaseOrderRepository(_context); }
        }

        public IPurchaseOrderItemRepository PurchaseOrderItemRepository
        {
            get { return _purchaseOrderItemRepository = _purchaseOrderItemRepository ?? new PurchaseOrderItemRepository(_context); }
        }

        public IShoppingCartRepository ShoppingCartRepository
        {
            get { return _shoppingCartRepository = _shoppingCartRepository ?? new ShoppingCartRepository(_context); }
        }

        public IShoppingCartItemRepository ShoppingCartItemRepository
        {
            get { return _shoppingCartItemRepository = _shoppingCartItemRepository ?? new ShoppingCartItemRepository(_context); }
        }

        public IUserAdminRepository UserAdminRepository
        {
            get { return _userAdminRepository = _userAdminRepository ?? new UserAdminRepository(_context); }
        }
        public IUserClientRepository UserClientRepository
        {
            get { return _userClientRepository = _userClientRepository ?? new UserClientRepository(_context); }
        }

        public IUserSellerRepository UserSellerRepository
        {
            get { return _userSellerRepository = _userSellerRepository ?? new UserSellerRepository(_context); }
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
