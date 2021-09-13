using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostgresqlExample.Data.Context;
using PostgresqlExample.Data.Interfaces;
using PostgresqlExample.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresqlExample.Data.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceToStartup(this IServiceCollection services)
        {
            //Dependency injection for ArticleRepository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //This method adds DbContext to services and gives connectionstring to Postgresql from appsetting.json. Also specifies the location of migration with MigrationsAssembly command.
            services.AddDbContext<PostgresqlExampleDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PostgresqlExample.Data")));
            //Dependency injection for DbContext.
            services.AddScoped<DbContext>(provider => provider.GetService<PostgresqlExampleDbContext>());
            return services;
        }
    }
}
