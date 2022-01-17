using Logiwa.ProductManagement.Business.Contracts.Abstracts;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;

namespace Logiwa.ProductManagement.Business.Product
{
    public interface IProductBusiness : IGenericBusiness<Entities.Product.Product, ProductDto, int>
    {
    }
}
