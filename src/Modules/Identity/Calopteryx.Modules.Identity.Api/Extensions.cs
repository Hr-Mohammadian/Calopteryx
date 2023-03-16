using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Calopteryx.Modules.Identity.Core;
using Calopteryx.Modules.Identity.Core.Auth;
using Calopteryx.Modules.Identity.Core.DAL;
using Calopteryx.Modules.Identity.Core.DAL.Seeders;
using Calopteryx.Modules.Identity.Core.Roles.Entities;
using Calopteryx.Modules.Identity.Core.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Calopteryx.Modules.Identity.Api;

public static class Extensions
{
    public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddCoreLayer(config);

        return services;
    }

    public static IApplicationBuilder UseIdentityModule(this IApplicationBuilder app, IServiceProvider services)
    {
        app.UseCurrentUser();
        var appcontext = services.GetRequiredService<IdentitiesDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
        services.GetRequiredService<IdentityDbSeeder>()
            .SeedIdentityDatabaseAsync(roleManager, userManager, appcontext);

        return app;
    }

    internal static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) =>
        app.UseMiddleware<CurrentUserMiddleware>();
}