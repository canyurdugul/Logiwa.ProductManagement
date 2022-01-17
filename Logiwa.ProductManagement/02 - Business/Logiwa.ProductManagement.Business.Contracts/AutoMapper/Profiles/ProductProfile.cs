using AutoMapper;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product.Product, ProductDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.StockQuantity, opts => opts.MapFrom(src => src.StockQuantity))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.IsDeleted, opts => opts.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.CreatedUtc, opts => opts.MapFrom(src => src.CreatedUtc)) ;

            CreateMap<ProductDto,Entities.Product.Product>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.StockQuantity, opts => opts.MapFrom(src => src.StockQuantity))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.IsDeleted, opts => opts.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.CreatedUtc, opts => opts.MapFrom(src => src.CreatedUtc));
        }
    }
}
