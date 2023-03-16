using System.Reflection;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Infrastructures.Database;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence.Repository;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;
using Calopteryx.Modules.Catalog.Core.DAL;
using Calopteryx.Modules.Catalog.Core.DAL.Repositories;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Calopteryx.Modules.Catalog.Shared;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Calopteryx.Modules.Catalog.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddPostgres<CatalogDbContext>();
        services.AddTransient<ICatalogModuleApi, CatalogModuleApi>();
        services.AddRepositories();
        var assembly = Assembly.GetExecutingAssembly();
        services
            .AddValidatorsFromAssembly(assembly)
            .AddMediatR(assembly); 
        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped(typeof(IRepository<Product>), typeof(CatalogDbRepository<Product>));
        services.AddScoped(typeof(IRepository<Brand>), typeof(CatalogDbRepository<Brand>));
        services.AddScoped(typeof(IReadRepository<Brand>), sp =>
            sp.GetRequiredService(typeof(IRepository<Brand>)));
        services.AddScoped(typeof(IReadRepository<Product>), sp =>
            sp.GetRequiredService(typeof(IRepository<Product>)));
            services.AddScoped(typeof(IRepositoryWithEvents<Product>), sp =>
                Activator.CreateInstance(
                    typeof(EventAddingRepositoryDecorator<Product>),
                    sp.GetRequiredService(typeof(IRepository<Product>)))
                ?? throw new InvalidOperationException($"Couldn't create EventAddingRepositoryDecorator for aggregateRootType Product")); 
            
            services.AddScoped(typeof(IRepositoryWithEvents<Brand>), sp =>
                Activator.CreateInstance(
                    typeof(EventAddingRepositoryDecorator<Brand>),
                    sp.GetRequiredService(typeof(IRepository<Brand>)))
                ?? throw new InvalidOperationException($"Couldn't create EventAddingRepositoryDecorator for aggregateRootType Product"));

        return services;
    }
}