

using Calopteryx.BuildingBlocks.Abstractions.Models;

namespace Calopteryx.Modules.Identity.Shared.Users.Dto;

public class UserListFilter : PaginationFilter
{
    public bool? IsActive { get; set; } 
}