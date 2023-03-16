using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Abstractions.Wrapper;
using Calopteryx.Modules.Identity.Core.Users.Requests;
using Calopteryx.Modules.Identity.Core.Users.Requests.Password;
using Calopteryx.Modules.Identity.Shared.RoleClaims.Dto;
using Calopteryx.Modules.Identity.Shared.Users.Dto;

namespace Calopteryx.Modules.Identity.Core.Users.Services;

public interface IUserService : ITransientService
{
    Task<PaginationResponse<UserDetailsDto>> SearchAsync(UserListFilter filter, CancellationToken cancellationToken);
    Task<Result<List<PermissionDto>>> GetResultedPermissionsAsync(string userId, CancellationToken cancellationToken);
    Task<bool> ExistsWithNameAsync(string name);
    Task<bool> ExistsWithEmailAsync(string email, string? exceptId = null);
    Task<bool> ExistsWithPhoneNumberAsync(string phoneNumber, string? exceptId = null);

    Task<List<UserDetailsDto>> GetListAsync(CancellationToken cancellationToken);

    Task<int> GetCountAsync(CancellationToken cancellationToken);

    Task<UserDetailsDto> GetAsync(string userId, CancellationToken cancellationToken);

    Task<List<UserRoleDto>> GetRolesAsync(string userId, CancellationToken cancellationToken);
    Task<string> AssignRolesAsync(string userId, UserRolesRequest request, CancellationToken cancellationToken);

    Task<List<string>> GetPermissionsAsync(string userId, CancellationToken cancellationToken);
    Task<bool> HasPermissionAsync(string userId, string permission, CancellationToken cancellationToken = default);
    Task InvalidatePermissionCacheAsync(string userId, CancellationToken cancellationToken);

    Task ToggleStatusAsync(ToggleUserStatusRequest request, CancellationToken cancellationToken);

    Task<string> GetOrCreateFromPrincipalAsync(ClaimsPrincipal principal);
    Task<string> CreateAsync(CreateUserRequest request, string origin);
    Task UpdateAsync(UpdateUserRequest request, string userId);

    Task<string> ConfirmEmailAsync(string userId, string code, string tenant, CancellationToken cancellationToken);
    Task<string> ConfirmPhoneNumberAsync(string userId, string code);

    Task<string> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
    Task<string> ResetPasswordAsync(ResetPasswordRequest request);
    Task ChangePasswordAsync(ChangePasswordRequest request, string userId);
}