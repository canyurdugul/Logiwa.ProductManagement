using AutoMapper;
using Logiwa.ProductManagement.Business.Contracts.Abstracts;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using Logiwa.ProductManagement.Business.Product;
using Logiwa.ProductManagement.Database.Repositories.ProductRepository;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Category
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductBusiness(IProductRepository _productRepository, IMapper _mapper)
        {
            productRepository = _productRepository;
            mapper = _mapper;
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

        public async Task<bool> InsertAsync(IUnitOfWork unitOfWork, ProductDto dto)
        {
            var entity = mapper.Map<Entities.Product.Product>(dto);
            return await productRepository.InsertAsync(unitOfWork, entity);
        }

        public async Task<bool> SoftDeleteAsync(IUnitOfWork unitOfWork,int id)
        {
            var data = await productRepository.GetByIdAsync(unitOfWork, id);
            data.IsDeleted = true;
           return await productRepository.UpdateAsync(unitOfWork, data);
        }

        public async Task<bool> UpdateAsync(IUnitOfWork unitOfWork, int id, ProductDto dto)
        {
            var data = await productRepository.GetByIdAsync(unitOfWork, id);
            var entity = mapper.Map<ProductDto, Entities.Product.Product>(dto, data);
            return await  productRepository.UpdateAsync(unitOfWork, entity);
        }
    }
}
