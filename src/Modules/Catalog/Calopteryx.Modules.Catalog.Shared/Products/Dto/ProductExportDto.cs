using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.Modules.Catalog.Shared.Products.Dto;

public class ProductExportDto : IDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Rate { get; set; } = default!;
    public string BrandName { get; set; } = default!;
}