using Microsoft.AspNetCore.Authorization;

namespace Calopteryx.BuildingBlocks.Abstractions.Authorization;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource) =>
        Policy = CalopteryxPermission.NameFor(action, resource);
}