using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ModelContext context) : base(context)
        {
        }

        //public Task<Category> FindCategoryAsync(string name)
        //{
        //    var category = GetItem(cat => cat.Label.Contains(categoryName)).ToList();
        //    return category;
        //}

    }
}
