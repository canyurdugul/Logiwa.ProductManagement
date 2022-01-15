using Logiwa.ProductManagement.Database.Repositories.GenericRepository.Concrete;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Entities.Product;

namespace Logiwa.ProductManagement.Database.Repositories.ProductRepository
{
    public class CategoryRepository : GenericRepository<Product, int>, ICategoryRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public CategoryRepository(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
