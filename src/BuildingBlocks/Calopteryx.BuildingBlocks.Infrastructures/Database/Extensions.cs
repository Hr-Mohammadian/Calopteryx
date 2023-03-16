using System;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Calopteryx.BuildingBlocks.Infrastructures.Database;

public static class Extensions
{
        
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<DbContextAppInitializer>();
        // Temporary fix for EF Core issue related to https://github.com/npgsql/efcore.pg/issues/2000
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IOptions<DatabaseSettings>>().Value;
        services.AddDbContext<T>(x => x.UseNpgsql(configuration.ConnectionString));
        // services.AddDbContext<T>(x => x.UseNpgsql(connectionString, e =>
        // e.MigrationsAssembly("Calopteryx.Bootstrapper")));
        return services;
    }
}