using Ardalis.Specification;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Abstractions.Queries;
using Calopteryx.BuildingBlocks.Infrastructures.Exceptions;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;
using Calopteryx.Modules.Catalog.Shared.Brands.Dto;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Calopteryx.Modules.Catalog.Core.Brands.Requests;

public class GetBrandQuery : IQuery<BrandDto>
{
    public Guid Id { get; set; }

    public GetBrandQuery(Guid id) => Id = id;
}

public class BrandByIdSpec : Specification<Brand, BrandDto>, ISingleResultSpecification
{
    public BrandByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetBrandQueryHandler : IQueryHandler<GetBrandQuery, BrandDto>
{
    private readonly IRepository<Brand> _repository;
    private readonly IStringLocalizer _t;

    public GetBrandQueryHandler(IRepository<Brand> repository, IStringLocalizer<GetBrandQueryHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<BrandDto> HandleAsync(GetBrandQuery request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Brand, BrandDto>)new BrandByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Brand {0} Not Found.", request.Id]);
}