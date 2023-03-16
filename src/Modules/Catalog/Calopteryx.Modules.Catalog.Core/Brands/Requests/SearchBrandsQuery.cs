using Ardalis.Specification;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Abstractions.Queries;
using Calopteryx.BuildingBlocks.Infrastructures.Specification;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;
using Calopteryx.Modules.Catalog.Shared.Brands.Dto;

namespace Calopteryx.Modules.Catalog.Core.Brands.Requests;

public class SearchBrandsQuery : PaginationFilter, IQuery<PaginationResponse<BrandDto>>
{
}

public class BrandsBySearchQuerySpec : EntitiesByPaginationFilterSpec<Brand, BrandDto>
{
    public BrandsBySearchQuerySpec(SearchBrandsQuery request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchBrandsQueryHandler : IQueryHandler<SearchBrandsQuery, PaginationResponse<BrandDto>>
{
    private readonly IReadRepository<Brand> _repository;


    public SearchBrandsQueryHandler(IReadRepository<Brand> repository) => _repository = repository;
   

    public async Task<PaginationResponse<BrandDto>> HandleAsync(SearchBrandsQuery request, CancellationToken cancellationToken)
    {
        var spec = new BrandsBySearchQuerySpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
       
    }
}