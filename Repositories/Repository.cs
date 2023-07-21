using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConstruAppAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ModelContext _context;

        public Repository(ModelContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetItem()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetItemByIdAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public void AddItem(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void DeleteItem(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void UpdateItem(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
