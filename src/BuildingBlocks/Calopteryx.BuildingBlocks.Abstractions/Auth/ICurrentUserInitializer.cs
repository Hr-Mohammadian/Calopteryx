using System.Security.Claims;

namespace Calopteryx.BuildingBlocks.Abstractions.Auth;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);

    void SetCurrentUserId(string userId);
}