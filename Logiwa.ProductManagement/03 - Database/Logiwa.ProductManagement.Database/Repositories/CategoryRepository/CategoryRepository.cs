using Logiwa.ProductManagement.Database.Repositories.GenericRepository.Concrete;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Entities.Category;

namespace Logiwa.ProductManagement.Database.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public CategoryRepository(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
