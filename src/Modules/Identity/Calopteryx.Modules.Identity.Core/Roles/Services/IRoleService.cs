using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Abstractions.Wrapper;
using Calopteryx.Modules.Identity.Core.RoleClaims.Responses;
using Calopteryx.Modules.Identity.Core.Roles.Requests;
using Calopteryx.Modules.Identity.Shared.Roles.Dto;

namespace Calopteryx.Modules.Identity.Core.Roles.Services;

public interface IRoleService : ITransientService
{
    Task<List<RoleDto>> GetListAsync(CancellationToken cancellationToken);
    Task<PaginationResponse<PaginatedRoleDto>> GetPaginatedListAsync(RoleListFilter roleFilter, CancellationToken cancellationToken);
    Task<int> GetCountAsync(CancellationToken cancellationToken);
    Task<Result<PermissionResponse>> GetAllPermissionsByRoleAsync(string roleId);
    Task<bool> ExistsAsync(string roleName, string? excludeId);

    Task<RoleDto> GetByIdAsync(string id);

    Task<RoleDto> GetByIdWithPermissionsAsync(string roleId, CancellationToken cancellationToken);

    Task<string> CreateOrUpdateAsync(CreateOrUpdateRoleRequest request);

    Task<string> UpdatePermissionsAsync(UpdateRolePermissionsRequest request, CancellationToken cancellationToken);

    Task<string> DeleteAsync(string id);
}