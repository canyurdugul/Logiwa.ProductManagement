using AutoMapper;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category.Category, CategoryDto>() 
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.MinimumStockQuantity, opts => opts.MapFrom(src => src.MinimumStockQuantity))
                .ForMember(dest => dest.IsDeleted, opts => opts.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.CreatedUtc, opts => opts.MapFrom(src => src.CreatedUtc))      ;


            CreateMap<CategoryDto,Entities.Category.Category>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.MinimumStockQuantity, opts => opts.MapFrom(src => src.MinimumStockQuantity))
                .ForMember(dest => dest.IsDeleted, opts => opts.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.CreatedUtc, opts => opts.MapFrom(src => src.CreatedUtc));
        }
    }
}
