namespace Calopteryx.Modules.Identity.Shared.Roles.Dto;

public class PaginatedRoleDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}