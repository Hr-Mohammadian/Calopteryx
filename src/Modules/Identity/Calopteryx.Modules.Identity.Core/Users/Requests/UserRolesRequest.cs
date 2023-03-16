using System.Collections.Generic;
using Calopteryx.Modules.Identity.Shared.Users.Dto;

namespace Calopteryx.Modules.Identity.Core.Users.Requests;

public class UserRolesRequest
{
    public List<UserRoleDto> UserRoles { get; set; } = new();
}