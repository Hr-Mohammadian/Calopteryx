using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Authorization;
using Calopteryx.Modules.Identity.Core.RoleClaims.Entities;
using Calopteryx.Modules.Identity.Core.Roles.Entities;
using Calopteryx.Modules.Identity.Core.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Calopteryx.Modules.Identity.Core.DAL.Seeders;

public class IdentityDbSeeder
{
    private IdentitiesDbContext _dbContext;
    private RoleManager<ApplicationRole> _roleManager;
    private UserManager<ApplicationUser> _userManager;
    private readonly ILogger<IdentityDbSeeder> _logger;

    public IdentityDbSeeder(ILogger<IdentityDbSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedIdentityDatabaseAsync(RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager, IdentitiesDbContext identitiesDbContext)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _dbContext = identitiesDbContext;

        _logger.LogInformation("Seeding ...");
       
            if (_dbContext.Database.GetPendingMigrations().Any())
            {
                _logger.LogInformation("Applying Migrations ...");
                 _dbContext.Database.Migrate();
            }

            if (_dbContext.Database.CanConnect())
            {
                _logger.LogInformation("Connection to Database Succeeded...");
                await SeedRolesAsync();
                await SeedAdminUserAsync();
            }
    }

    private async Task SeedRolesAsync()
    {
        foreach (string roleName in CalopteryxRoles.DefaultRoles)
        {
            if (await _roleManager.Roles.SingleOrDefaultAsync(r => r.Name == roleName)
                is not ApplicationRole role)
            {
                // Create the role
                _logger.LogInformation("Seeding {role} Role.", roleName);
                role = new ApplicationRole(roleName, $"{roleName} Role ");
                await _roleManager.CreateAsync(role);
            }

            // Assign permissions
            if (roleName == CalopteryxRoles.Basic)
            {
                await AssignPermissionsToRoleAsync(CalopteryxPermissions.Basic, role);
            }
            else if (roleName == CalopteryxRoles.Admin)
            {
                await AssignPermissionsToRoleAsync(CalopteryxPermissions.Admin, role);
            }
        }
    }

    private async Task AssignPermissionsToRoleAsync(IReadOnlyList<CalopteryxPermission> permissions, ApplicationRole role)
    {
        var currentClaims = await _roleManager.GetClaimsAsync(role);
        foreach (var permission in permissions)
        {
            if (!currentClaims.Any(c => c.Type == CalopteryxClaims.Permission && c.Value == permission.Name))
            {
                _logger.LogInformation("Seeding {role} Permission '{permission}'.", role.Name, permission.Name);
                _dbContext.RoleClaims.Add(new ApplicationRoleClaim
                {
                    RoleId = role.Id,
                    ClaimType = CalopteryxClaims.Permission,
                    ClaimValue = permission.Name,
                    CreatedBy = "ApplicationDbSeeder"
                });
                await _dbContext.SaveChangesAsync();
            }
        }
    }

    private async Task SeedAdminUserAsync()
    {
        if (await _userManager.Users.FirstOrDefaultAsync(u => u.Email == "admin@calopteryx.com")
            is not ApplicationUser adminUser)
        {
            string adminUserName = $"{CalopteryxRoles.Admin}".ToLowerInvariant();
            adminUser = new ApplicationUser
            {
                FirstName = "admin-first-name",
                LastName = CalopteryxRoles.Admin,
                Email = "admin@calopteryx.com",
                UserName = adminUserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NormalizedEmail = "admin@calopteryx.com"?.ToUpperInvariant(),
                NormalizedUserName = adminUserName.ToUpperInvariant(),
                IsActive = true
            };

            _logger.LogInformation("Seeding Default Admin User .");
            var password = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = password.HashPassword(adminUser, "password");
            await _userManager.CreateAsync(adminUser);
        }

        // Assign role to user
        if (!await _userManager.IsInRoleAsync(adminUser, CalopteryxRoles.Admin))
        {
            _logger.LogInformation("Assigning Admin Role to Admin User .");
            await _userManager.AddToRoleAsync(adminUser, CalopteryxRoles.Admin);
        }
    }
}