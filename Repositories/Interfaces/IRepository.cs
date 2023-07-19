using System.Linq.Expressions;

namespace ConstruAppAPI.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetItem();
        Task<T> GetItemByIdAsync(Expression<Func<T, bool>> predicate);
        void AddItem(T entity);
        void UpdateItem(T entity);
        void DeleteItem(T entity);
    }
}
