using Logiwa.ProductManagement.Database.Repositories.GenericRepository.Concrete;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Entities.Product;

namespace Logiwa.ProductManagement.Database.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ProductRepository(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
