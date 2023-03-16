using System;
using Calopteryx.Modules.Identity.Core.Roles.Entities;
using Microsoft.AspNetCore.Identity;

namespace Calopteryx.Modules.Identity.Core.RoleClaims.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public string? CreatedBy { get; init; }
    public DateTime CreatedOn { get; init; }
    public virtual ApplicationRole Role { get; set; }
}