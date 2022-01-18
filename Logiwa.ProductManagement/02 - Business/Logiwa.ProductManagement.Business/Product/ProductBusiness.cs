using AutoMapper;
using Logiwa.ProductManagement.Business.Contracts.Abstracts;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using Logiwa.ProductManagement.Business.Product;
using Logiwa.ProductManagement.Database.Repositories.ProductRepository;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Category
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly ICategoryBusiness categoryBusiness;

        public ProductBusiness(IMapper _mapper, IProductRepository _productRepository, ICategoryBusiness _categoryBusiness)
        {
            mapper = _mapper;
            productRepository = _productRepository;
            categoryBusiness = _categoryBusiness;
        }

        public async Task<bool> DeleteById(IUnitOfWork unitOfWork, int id)
        {
            var entity = await productRepository.GetByIdAsync(unitOfWork, id);
            await productRepository.DeleteAsync(unitOfWork, entity);
            return true;
        }

        public async Task<ProductDto> GetByIdAsync(IUnitOfWork unitOfWork, int id)
        {
            var data = await productRepository.GetByIdAsync(unitOfWork, id);
            return mapper.Map<ProductDto>(data);
        }

        public async Task<IEnumerable<ProductDto>> GetListAsync(IUnitOfWork unitOfWork)
        {
            var data = await productRepository.GetListAsync(unitOfWork);
            return mapper.Map<List<ProductDto>>(data);
        }


        public IEnumerable<ProductDto> SearchProduct(IUnitOfWork unitOfWork, SearchProductDto searchProductDto)
        {
            var data = productRepository.GetIQueryable(unitOfWork);

            if (!string.IsNullOrEmpty(searchProductDto.Keyword))
            {
                data = data.Where(w => EF.Functions.Like(w.Title, $"%{searchProductDto.Keyword}%") ||
                                       EF.Functions.Like(w.Description, $"%{searchProductDto.Keyword}%") ||
                                       EF.Functions.Like(w.Category.Name, $"%{searchProductDto.Keyword}%"));
            }
            if (searchProductDto.MinimumStockQuantity.HasValue)
                data = data.Where(w => w.StockQuantity >= searchProductDto.MinimumStockQuantity.Value);
            if (searchProductDto.MaximumStockQuantity.HasValue)
                data = data.Where(w => w.StockQuantity >= searchProductDto.MinimumStockQuantity.Value);             

            return mapper.Map<List<ProductDto>>(data.ToList());
        }

        public async Task<bool> InsertAsync(IUnitOfWork unitOfWork, ProductDto dto)
        {
            var entity = mapper.Map<Entities.Product.Product>(dto);
            return await productRepository.InsertAsync(unitOfWork, entity);
        }

        public async Task<bool> SoftDeleteAsync(IUnitOfWork unitOfWork, int id)
        {
            var data = await productRepository.GetByIdAsync(unitOfWork, id);
            data.IsDeleted = true;
            return await productRepository.UpdateAsync(unitOfWork, data);
        }

        public async Task<bool> UpdateAsync(IUnitOfWork unitOfWork, int id, ProductDto dto)
        {
            var data = await productRepository.GetByIdAsync(unitOfWork, id);
            var entity = mapper.Map<ProductDto, Entities.Product.Product>(dto, data);
            return await productRepository.UpdateAsync(unitOfWork, entity);
        }
    }
}
