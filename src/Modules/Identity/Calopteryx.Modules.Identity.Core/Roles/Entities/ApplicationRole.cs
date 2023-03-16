using System.Collections.Generic;
using Calopteryx.Modules.Identity.Core.RoleClaims.Entities;
using Microsoft.AspNetCore.Identity;

namespace Calopteryx.Modules.Identity.Core.Roles.Entities;

public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }
    public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    public ApplicationRole(string name, string? description = null)
        : base(name)
    {
        Description = description;
        NormalizedName = name.ToUpperInvariant();
    }
}