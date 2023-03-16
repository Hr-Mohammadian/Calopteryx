﻿using Ardalis.Specification;
using Calopteryx.BuildingBlocks.Abstractions.Exporters;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Infrastructures.Specification;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Calopteryx.Modules.Catalog.Shared.Products.Dto;
using MediatR;

namespace Calopteryx.Modules.Catalog.Core.Products.Requests;

public class ExportProductsRequest : BaseFilter, IRequest<Stream>
{
    public Guid? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class ExportProductsRequestHandler : IRequestHandler<ExportProductsRequest, Stream>
{
    private readonly IReadRepository<Product> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportProductsRequestHandler(IReadRepository<Product> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportProductsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportProductsWithBrandsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportProductsWithBrandsSpecification : EntitiesByBaseFilterSpec<Product, ProductExportDto>
{
    public ExportProductsWithBrandsSpecification(ExportProductsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Brand)
            .Where(p => p.BrandId.Equals(request.BrandId!.Value), request.BrandId.HasValue)
            .Where(p => p.Rate >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
            .Where(p => p.Rate <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
}