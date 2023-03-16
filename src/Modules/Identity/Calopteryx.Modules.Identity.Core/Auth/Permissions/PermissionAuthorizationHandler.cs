using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Authorization;
using Calopteryx.Modules.Identity.Core.Users.Services;
using Microsoft.AspNetCore.Authorization;

namespace Calopteryx.Modules.Identity.Core.Auth.Permissions;

internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IUserService _userService;

    public PermissionAuthorizationHandler(IUserService userService) =>
        _userService = userService;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User?.GetUserId() is { } userId &&
            await _userService.HasPermissionAsync(userId, requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}