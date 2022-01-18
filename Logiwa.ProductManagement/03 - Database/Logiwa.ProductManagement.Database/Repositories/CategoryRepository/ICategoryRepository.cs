using Logiwa.ProductManagement.Database.Repositories.GenericRepository.Abstract;
using Logiwa.ProductManagement.Entities.Category;

namespace Logiwa.ProductManagement.Database.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category, int> { }
}
