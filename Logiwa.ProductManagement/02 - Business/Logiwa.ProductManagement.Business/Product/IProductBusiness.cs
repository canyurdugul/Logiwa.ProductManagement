using Logiwa.ProductManagement.Business.Contracts.Abstracts;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Product
{
    public interface IProductBusiness : IGenericBusiness<Entities.Product.Product, ProductDto, int>
    {
        IEnumerable<ProductDto> SearchProduct(IUnitOfWork unitOfWork, SearchProductDto searchProductDto);
    }
}
