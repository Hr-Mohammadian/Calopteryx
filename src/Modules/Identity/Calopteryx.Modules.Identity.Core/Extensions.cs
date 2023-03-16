using System.Reflection;
using Calopteryx.Modules.Identity.Core.Mapping;
using Calopteryx.Modules.Identity.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Calopteryx.BuildingBlocks.Abstractions.Auth;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.BuildingBlocks.Infrastructures.Database;
using Calopteryx.Modules.Identity.Core.Audits.Requests;
using Calopteryx.Modules.Identity.Core.Audits.Services;
using Calopteryx.Modules.Identity.Core.Auth;
using Calopteryx.Modules.Identity.Core.Auth.Jwt;
using Calopteryx.Modules.Identity.Core.Auth.Permissions;
using Calopteryx.Modules.Identity.Core.DAL;
using Calopteryx.Modules.Identity.Core.DAL.Seeders;
using Calopteryx.Modules.Identity.Core.Roles.Entities;
using Calopteryx.Modules.Identity.Core.Users.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
namespace Calopteryx.Modules.Identity.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services, IConfiguration config)
    {
        MapsterSettings.Configure();
        services.AddPostgres<IdentitiesDbContext>();
        services.AddAuth(config);
        services.AddTransient<IIdentityModuleApi, IdentityModuleApi>();
        services.AddTransient<IIdentityAuditService, IdentityAuditService>();
        services.AddTransient<IdentityDbSeeder>();
        var assembly = Assembly.GetExecutingAssembly();
        services
            .AddValidatorsFromAssembly(assembly)
            .AddMediatR(assembly);

            
        return services;
    }
    internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddCurrentUser()
            .AddPermissions()

            // Must add identity before adding auth!
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<IdentitiesDbContext>()
            .AddDefaultTokenProviders();
        services.Configure<SecuritySettings>(config.GetSection(nameof(SecuritySettings)));
        return  services.AddJwtAuth(config);
    }

    

    private static IServiceCollection AddCurrentUser(this IServiceCollection services) =>
        services
            .AddScoped<CurrentUserMiddleware>()
            .AddScoped<ICurrentUser, CurrentUser>()
            .AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());

    private static IServiceCollection AddPermissions(this IServiceCollection services) =>
        services
            .AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
            .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
}