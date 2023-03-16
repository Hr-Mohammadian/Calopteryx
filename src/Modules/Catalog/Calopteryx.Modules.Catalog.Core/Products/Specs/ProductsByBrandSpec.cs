using Ardalis.Specification;
using Calopteryx.Modules.Catalog.Core.Products.Entities;

namespace Calopteryx.Modules.Catalog.Core.Products.Specs;

public class ProductsByBrandSpec : Specification<Product>
{
    public ProductsByBrandSpec(Guid brandId) =>
        Query.Where(p => p.BrandId == brandId);
}
