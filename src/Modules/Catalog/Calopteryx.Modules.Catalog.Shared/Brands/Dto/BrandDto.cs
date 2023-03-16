using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.Modules.Catalog.Shared.Brands.Dto;

public class BrandDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}