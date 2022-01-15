﻿using Logiwa.ProductManagement.Database.Data;
using Logiwa.ProductManagement.Database.Data.Factory;
using Logiwa.ProductManagement.Database.Data.MicrosoftSQLServer;
using Logiwa.ProductManagement.Database.Data.PostgreSQL;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Database.UnitOfWork.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Logiwa.ProductManagement.Client.Api
{
    public class BaseBootstrapper
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration configuration;
        private string databaseProvider;


        public BaseBootstrapper(IServiceCollection services, IConfiguration configuration) { this.services = services; this.configuration = configuration; this.databaseProvider = this.configuration.GetValue<string>("DatabaseProvider");  Install(); }

        private void Install()
        {
            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

            if(databaseProvider == "MSSQL")
            {
                using (var context = new LPMMSSQLDbContext())
                {
                    context.Database.Migrate();
                }
            }
            else if(databaseProvider == "POSTGRESQL")
            {
                using (var context = new LPMPostgreSQLDbContext())
                {
                    context.Database.Migrate();
                }
            }

        }
    }
}