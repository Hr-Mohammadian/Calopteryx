using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Authorization;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Infrastructures.Controller;
using Calopteryx.BuildingBlocks.Infrastructures.OpenApi;
using Calopteryx.Modules.Identity.Core.Auth.Permissions;
using Calopteryx.Modules.Identity.Core.Users.Requests;
using Calopteryx.Modules.Identity.Core.Users.Requests.Password;
using Calopteryx.Modules.Identity.Core.Users.Services;
using Calopteryx.Modules.Identity.Shared.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Calopteryx.Modules.Identity.Api.Controllers;

public class UsersController : VersionNeutralApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.Users)]
    [OpenApiOperation("Get list of all users.", "")]
    public Task<List<UserDetailsDto>> GetListAsync(CancellationToken cancellationToken)
    {
        return _userService.GetListAsync(cancellationToken);
    }

    [HttpPost("search")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.Users)]
    [OpenApiOperation("Get paginated list of all users.", "")]
    public Task<PaginationResponse<UserDetailsDto>> SearchAsync(UserListFilter filter, CancellationToken cancellationToken)
    {
        return _userService.SearchAsync(filter, cancellationToken);
    }

    [HttpGet("{id}")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.Users)]
    [OpenApiOperation("Get a user's details.", "")]
    public Task<UserDetailsDto> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        return _userService.GetAsync(id, cancellationToken);
    }

    [HttpGet("{id}/roles")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.UserRoles)]
    [OpenApiOperation("Get a user's roles.", "")]
    public Task<List<UserRoleDto>> GetRolesAsync(string id, CancellationToken cancellationToken)
    {
        return _userService.GetRolesAsync(id, cancellationToken);
    }

    [HttpPost("{id}/roles")]
    [ApiConventionMethod(typeof(CalopteryxApiConventions), nameof(CalopteryxApiConventions.Register))]
    [MustHavePermission(CalopteryxAction.Update, CalopteryxResource.UserRoles)]
    [OpenApiOperation("Update a user's assigned roles.", "")]
    public Task<string> AssignRolesAsync(string id, UserRolesRequest request, CancellationToken cancellationToken)
    {
        return _userService.AssignRolesAsync(id, request, cancellationToken);
    }

    [HttpPost]
    [MustHavePermission(CalopteryxAction.Create, CalopteryxResource.Users)]
    [OpenApiOperation("Creates a new user.", "")]
    public Task<string> CreateAsync(CreateUserRequest request)
    {
        return _userService.CreateAsync(request, GetOriginFromRequest());
    }

    [HttpPost("self-register")]
    [AllowAnonymous]
    [OpenApiOperation("Anonymous user creates a user.", "")]
    [ApiConventionMethod(typeof(CalopteryxApiConventions), nameof(CalopteryxApiConventions.Register))]
    public Task<string> SelfRegisterAsync(CreateUserRequest request)
    {
        //todo captcha / throttle
        return _userService.CreateAsync(request, GetOriginFromRequest());
    }

    [HttpPost("{id}/toggle-status")]
    [MustHavePermission(CalopteryxAction.Update, CalopteryxResource.Users)]
    [ApiConventionMethod(typeof(CalopteryxApiConventions), nameof(CalopteryxApiConventions.Register))]
    [OpenApiOperation("Toggle a user's active status.", "")]
    public async Task<ActionResult> ToggleStatusAsync(string id, ToggleUserStatusRequest request, CancellationToken cancellationToken)
    {
        if (id != request.UserId)
        {
            return BadRequest();
        }

        await _userService.ToggleStatusAsync(request, cancellationToken);
        return Ok();
    }

    [HttpGet("confirm-email")]
    [AllowAnonymous]
    [OpenApiOperation("Confirm email address for a user.", "")]
    [ApiConventionMethod(typeof(CalopteryxApiConventions), nameof(CalopteryxApiConventions.Search))]
    public Task<string> ConfirmEmailAsync([FromQuery] string tenant, [FromQuery] string userId, [FromQuery] string code, CancellationToken cancellationToken)
    {
        return _userService.ConfirmEmailAsync(userId, code, tenant, cancellationToken);
    }

    [HttpGet("confirm-phone-number")]
    [AllowAnonymous]
    [OpenApiOperation("Confirm phone number for a user.", "")]
    [ApiConventionMethod(typeof(CalopteryxApiConventions), nameof(CalopteryxApiConventions.Search))]
    public Task<string> ConfirmPhoneNumberAsync([FromQuery] string userId, [FromQuery] string code)
    {
        return _userService.ConfirmPhoneNumberAsync(userId, code);
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    [OpenApiOperation("Request a password reset email for a user.", "")]
    [ApiConventionMethod(typeof(CalopteryxApiConventions), nameof(CalopteryxApiConventions.Register))]
    public Task<string> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        return _userService.ForgotPasswordAsync(request, GetOriginFromRequest());
    }

    [HttpPost("reset-password")]
    [OpenApiOperation("Reset a user's password.", "")]
    [ApiConventionMethod(typeof(CalopteryxApiConventions), nameof(CalopteryxApiConventions.Register))]
    public Task<string> ResetPasswordAsync(ResetPasswordRequest request)
    {
        return _userService.ResetPasswordAsync(request);
    }

    private string GetOriginFromRequest() => $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
}
