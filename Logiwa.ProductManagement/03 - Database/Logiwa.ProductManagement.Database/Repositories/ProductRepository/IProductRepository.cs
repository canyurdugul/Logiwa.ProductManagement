using Logiwa.ProductManagement.Database.Repositories.GenericRepository.Abstract;
using Logiwa.ProductManagement.Entities.Product;

namespace Logiwa.ProductManagement.Database.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product, int> { }
}
