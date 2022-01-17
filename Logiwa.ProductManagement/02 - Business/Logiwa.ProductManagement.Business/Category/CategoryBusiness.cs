using AutoMapper;
using Logiwa.ProductManagement.Business.Contracts.Abstracts;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Database.Repositories.CategoryRepository;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Category
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryBusiness(ICategoryRepository _categoryRepository, IMapper _mapper)
        {
            categoryRepository = _categoryRepository;
            mapper = _mapper;
        }

        public async Task<bool> DeleteById(IUnitOfWork unitOfWork, int id)
        {
            var entity = await categoryRepository.GetByIdAsync(unitOfWork, id);
            await categoryRepository.DeleteAsync(unitOfWork, entity);
            return true;
        }

        public async Task<CategoryDto> GetByIdAsync(IUnitOfWork unitOfWork, int id)
        {
            var data = await categoryRepository.GetByIdAsync(unitOfWork, id);
            return mapper.Map<CategoryDto>(data);
        }

        public async Task<IEnumerable<CategoryDto>> GetListAsync(IUnitOfWork unitOfWork)
        {
            var data = await categoryRepository.GetListAsync(unitOfWork);
            return mapper.Map<List<CategoryDto>>(data);
        }

        public async Task<bool> InsertAsync(IUnitOfWork unitOfWork, CategoryDto dto)
        {
            var entity = mapper.Map<Entities.Category.Category>(dto);
            return await categoryRepository.InsertAsync(unitOfWork, entity);
        }

        public async Task<bool> SoftDeleteAsync(IUnitOfWork unitOfWork,int id)
        {
            var data = await categoryRepository.GetByIdAsync(unitOfWork, id);
            data.IsDeleted = true;
           return await categoryRepository.UpdateAsync(unitOfWork, data);
        }

        public async Task<bool> UpdateAsync(IUnitOfWork unitOfWork, int id, CategoryDto dto)
        {
            var data = await categoryRepository.GetByIdAsync(unitOfWork, id);
            var entity = mapper.Map<CategoryDto, Entities.Category.Category>(dto, data);
            return await  categoryRepository.UpdateAsync(unitOfWork, entity);
        }
    }
}
