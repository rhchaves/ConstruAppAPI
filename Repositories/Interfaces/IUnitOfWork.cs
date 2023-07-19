namespace ConstruAppAPI.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPurchaseOrderRepository PurchaseOrderRepository { get; }
        IPurchaseOrderItemRepository PurchaseOrderItemRepository { get; }
        IShoppingCartRepository ShoppingCartRepository  { get; }
        IUserAdminRepository UserAdminRepository { get; }
        IUserClientRepository UserClientRepository { get; }
        IUserSellerRepository UserSellerRepository { get; }
        Task CommitAsync();
    }
}
