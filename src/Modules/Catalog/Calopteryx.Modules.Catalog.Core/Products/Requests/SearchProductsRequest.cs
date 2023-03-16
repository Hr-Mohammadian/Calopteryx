using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Calopteryx.Modules.Catalog.Core.Products.Specs;
using Calopteryx.Modules.Catalog.Shared.Products.Dto;
using MediatR;

namespace Calopteryx.Modules.Catalog.Core.Products.Requests;

public class SearchProductsRequest : PaginationFilter, IRequest<PaginationResponse<ProductDto>>
{
    public Guid? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchProductsRequestHandler : IRequestHandler<SearchProductsRequest, PaginationResponse<ProductDto>>
{
    private readonly IReadRepository<Product> _repository;

    public SearchProductsRequestHandler(IReadRepository<Product> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductDto>> Handle(SearchProductsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductsBySearchRequestWithBrandsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}