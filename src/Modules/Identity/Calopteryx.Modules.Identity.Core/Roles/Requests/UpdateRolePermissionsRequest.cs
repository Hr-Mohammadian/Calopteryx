

using System.Collections.Generic;
using Calopteryx.BuildingBlocks.Abstractions.Validation;
using FluentValidation;

namespace Calopteryx.Modules.Identity.Core.Roles.Requests;

public class UpdateRolePermissionsRequest
{
    public string RoleId { get; set; } = default!;
    public List<string> Permissions { get; set; } = default!;
}

public class UpdateRolePermissionsRequestValidator : CustomValidator<UpdateRolePermissionsRequest>
{
    public UpdateRolePermissionsRequestValidator()
    {
        RuleFor(r => r.RoleId)
            .NotEmpty();
        RuleFor(r => r.Permissions)
            .NotNull();
    }
}