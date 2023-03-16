
using System.Reflection;
using Calopteryx.Modules.Catalog.Core;
using Calopteryx.Modules.Catalog.Core.Brands.Requests;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Calopteryx.Modules.Catalog.Api;

public static class Extensions
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services)
    {
        services.AddCoreLayer();
        return services;
    }
        
    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        return app;
    }
}