using Logiwa.ProductManagement.Business.Contracts.Abstracts;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;

namespace Logiwa.ProductManagement.Business.Category
{
    public interface ICategoryBusiness : IGenericBusiness<Entities.Category.Category, CategoryDto, int>
    {
    }
}
