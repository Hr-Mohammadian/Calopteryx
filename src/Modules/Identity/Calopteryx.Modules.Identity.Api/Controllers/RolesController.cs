using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Authorization;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Abstractions.Wrapper;
using Calopteryx.BuildingBlocks.Infrastructures.Controller;
using Calopteryx.Modules.Identity.Core.Auth.Permissions;
using Calopteryx.Modules.Identity.Core.RoleClaims.Responses;
using Calopteryx.Modules.Identity.Core.Roles.Requests;
using Calopteryx.Modules.Identity.Core.Roles.Services;
using Calopteryx.Modules.Identity.Shared.Roles.Dto;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Calopteryx.Modules.Identity.Api.Controllers;

public class RolesController : VersionNeutralApiController
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService) => _roleService = roleService;

    [HttpGet]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.Roles)]
    [OpenApiOperation("Get a list of all roles.", "")]
    public Task<List<RoleDto>> GetListAsync(CancellationToken cancellationToken)
    {
        return _roleService.GetListAsync(cancellationToken);
    }

    [HttpPost("search")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.Roles)]
    [OpenApiOperation("Get a paginated list of all roles.", "")]
    public async Task<PaginationResponse<PaginatedRoleDto>> GetPaginatedListAsync(RoleListFilter roleFilter, CancellationToken cancellationToken)
    {
        return await _roleService.GetPaginatedListAsync(roleFilter, cancellationToken);
    }

    [HttpGet("{id}")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.Roles)]
    [OpenApiOperation("Get role details.", "")]
    public Task<RoleDto> GetByIdAsync(string id)
    {
        return _roleService.GetByIdAsync(id);
    }

    [HttpGet("{id}/permissions")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.RoleClaims)]
    [OpenApiOperation("Get role details with its permissions.", "")]
    public Task<Result<PermissionResponse>> GetByIdWithPermissionsAsync(string id, CancellationToken cancellationToken)
    {
        return _roleService.GetAllPermissionsByRoleAsync(id);
    }

    [HttpPut("{id}/permissions")]
    [MustHavePermission(CalopteryxAction.Update, CalopteryxResource.RoleClaims)]
    [OpenApiOperation("Update a role's permissions.", "")]
    public async Task<ActionResult<string>> UpdatePermissionsAsync(string id, UpdateRolePermissionsRequest request, CancellationToken cancellationToken)
    {
        if (id != request.RoleId)
        {
            return BadRequest();
        }

        return Ok(await _roleService.UpdatePermissionsAsync(request, cancellationToken));
    }

    [HttpPost]
    [MustHavePermission(CalopteryxAction.Create, CalopteryxResource.Roles)]
    [OpenApiOperation("Create or update a role.", "")]
    public Task<string> RegisterRoleAsync(CreateOrUpdateRoleRequest request)
    {
        return _roleService.CreateOrUpdateAsync(request);
    }

    [HttpDelete("{id}")]
    [MustHavePermission(CalopteryxAction.Delete, CalopteryxResource.Roles)]
    [OpenApiOperation("Delete a role.", "")]
    public Task<string> DeleteAsync(string id)
    {
        return _roleService.DeleteAsync(id);
    }
}