using AutoMapper;
using FluentValidation;
using Logiwa.ProductManagement.Business.Category;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using Logiwa.ProductManagement.Business.Contracts.Validations;
using Logiwa.ProductManagement.Database.Data.Factory;
using Logiwa.ProductManagement.Database.Data.MicrosoftSQLServer;
using Logiwa.ProductManagement.Database.Repositories.CategoryRepository;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Database.UnitOfWork.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logiwa.ProductManagement.Client.Api
{
    public class BaseBootstrapper
    {
        private readonly IServiceCollection services;

        public BaseBootstrapper(IServiceCollection services, IConfiguration configuration) { this.services = services; Install(); }

        private void Install()
        {
            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryBusiness, CategoryBusiness>();

            //services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IValidator<ProductDto>, ProductValidation>();
            services.AddTransient<IValidator<CategoryDto>, CategoryValidation>();
        }
    }
}
