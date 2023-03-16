using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.Modules.Catalog.Shared.Brands.Dto;

namespace Calopteryx.Modules.Catalog.Shared.Products.Dto;

public class ProductDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Rate { get; set; }
    public string? ImagePath { get; set; }
    public BrandDto Brand { get; set; } = default!;
}