using System.Reflection;
using Calopteryx.BuildingBlocks.Abstractions.Dispatchers;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Abstractions.Queries;
using Calopteryx.BuildingBlocks.Abstractions.Time;
using Calopteryx.BuildingBlocks.Infrastructures.BackgroundJobs;
using Calopteryx.BuildingBlocks.Infrastructures.Caching;
using Calopteryx.BuildingBlocks.Infrastructures.Commands;
using Calopteryx.BuildingBlocks.Infrastructures.Common;
using Calopteryx.BuildingBlocks.Infrastructures.Cors;
using Calopteryx.BuildingBlocks.Infrastructures.Database;
using Calopteryx.BuildingBlocks.Infrastructures.FileStorage;
using Calopteryx.BuildingBlocks.Infrastructures.Localization;
using Calopteryx.BuildingBlocks.Infrastructures.Mailing;
using Calopteryx.BuildingBlocks.Infrastructures.Messaging;
using Calopteryx.BuildingBlocks.Infrastructures.Middleware;
using Calopteryx.BuildingBlocks.Infrastructures.Notifications;
using Calopteryx.BuildingBlocks.Infrastructures.OpenApi;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence;
using Calopteryx.BuildingBlocks.Infrastructures.SecurityHeaders;
using Calopteryx.BuildingBlocks.Infrastructures.Dispatchers;
using Calopteryx.BuildingBlocks.Infrastructures.Events;

using Calopteryx.BuildingBlocks.Infrastructures.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calopteryx.BuildingBlocks.Infrastructures;

public static class Extensions
{
        
    public static IServiceCollection AddSharedFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCommands();
        services.AddEvents();
        services.AddQueries();
        services.AddMessaging();
        services.AddPostgres(configuration);
        services.AddSingleton<IClock, UtcClock>();
        services.AddSingleton<IDispatcher, InMemoryDispatcher>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      
       
        return services;
    }
         
    public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services
            .AddApiVersioning()
            .AddBackgroundJobs(configuration)
            .AddCaching(configuration)
            .AddCorsPolicy(configuration)
            .AddExceptionMiddleware()
            .AddHealthCheck()
            .AddPOLocalization(configuration)
            .AddMailing(configuration)
            .AddNotifications(configuration)
            .AddOpenApiDocumentation(configuration)
            .AddPersistence(configuration)
            .AddRequestLogging(configuration)
            .AddRouting(options => options.LowercaseUrls = true)
            .AddServices();
       
        return services;
    }
       
    private static IServiceCollection AddApiVersioning(this IServiceCollection services) =>
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });

    private static IServiceCollection AddHealthCheck(this IServiceCollection services) =>
        services.AddHealthChecks().Services;

    public static async Task InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        // Create a new scope to retrieve scoped services
        using var scope = services.CreateScope();

        await scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>()
            .InitializeDatabasesAsync(cancellationToken);
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            .UseRequestLocalization()
            .UseStaticFiles()
            .UseSecurityHeaders(config)
            .UseFileStorage()
            .UseExceptionMiddleware()
            .UseRouting()
            .UseCorsPolicy()
            .UseAuthentication()
            .UseAuthorization()
            .UseRequestLogging(config)
            .UseHangfireDashboard(config)
            .UseOpenApiDocumentation(config);

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapControllers().RequireAuthorization();
        builder.MapHealthCheck();
        builder.MapNotifications();
        return builder;
    }

    private static IEndpointConventionBuilder MapHealthCheck(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapHealthChecks("/api/health").RequireAuthorization();
    public static IApplicationBuilder UseSharedFramework(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseInfrastructure(configuration);
            
        return app;
    }
}