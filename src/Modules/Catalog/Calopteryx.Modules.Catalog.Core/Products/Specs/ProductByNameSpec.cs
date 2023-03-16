using Ardalis.Specification;
using Calopteryx.Modules.Catalog.Core.Products.Entities;

namespace Calopteryx.Modules.Catalog.Core.Products.Specs;

public class ProductByNameSpec : Specification<Product>, ISingleResultSpecification
{
    public ProductByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}