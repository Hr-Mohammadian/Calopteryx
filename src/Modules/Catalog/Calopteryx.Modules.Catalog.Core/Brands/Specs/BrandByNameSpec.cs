using Ardalis.Specification;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;

namespace Calopteryx.Modules.Catalog.Core.Brands.Specs;

public class BrandByNameSpec : Specification<Brand>, ISingleResultSpecification
{
    public BrandByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}