namespace ConstruAppAPI.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserAdminRepository UserAdminRepository { get; }
        IUserClientRepository UserClientRepository { get; }
        IUserSellerRepository UserSellerRepository { get; }
        Task CommitAsync();
    }
}
