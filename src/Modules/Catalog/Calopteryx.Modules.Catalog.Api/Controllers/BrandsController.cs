using Calopteryx.BuildingBlocks.Abstractions.Authorization;
using Calopteryx.BuildingBlocks.Abstractions.Dispatchers;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Infrastructures.Controller;
using Calopteryx.Modules.Catalog.Core.Brands.Requests;
using Calopteryx.Modules.Catalog.Shared.Brands.Dto;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Calopteryx.Modules.Catalog.Api.Controllers;

public class BrandsController : VersionNeutralApiController
{
    private readonly IDispatcher _dispatcher;

    public BrandsController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost("search")]
    [MustHavePermission(CalopteryxAction.Search, CalopteryxResource.Brands)]
    [OpenApiOperation("Search brands using available filters.", "")]
    public async Task<PaginationResponse<BrandDto>> SearchAsync(SearchBrandsQuery query)
    {
        return await _dispatcher.QueryAsync(query);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.Brands)]
    [OpenApiOperation("Get brand details.", "")]
    public Task<BrandDto> GetAsync(Guid id)
    {
        return _dispatcher.QueryAsync(new GetBrandQuery(id));
    }

    [HttpPost("create")]
    [MustHavePermission(CalopteryxAction.Create, CalopteryxResource.Brands)]
    [OpenApiOperation("Create a new brand.", "")]
    public Task CreateAsync(CreateBrandCommand command)
    {
        return _dispatcher.SendAsync(command);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(CalopteryxAction.Update, CalopteryxResource.Brands)]
    [OpenApiOperation("Update a brand.", "")]
    public async Task<IActionResult> UpdateAsync(UpdateBrandCommand command, Guid id)
    {
        if (id != command.Id)
            return BadRequest();
        await _dispatcher.SendAsync(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(CalopteryxAction.Delete, CalopteryxResource.Brands)]
    [OpenApiOperation("Delete a brand.", "")]
    public Task DeleteAsync(Guid id)
    {
        return _dispatcher.SendAsync(new DeleteBrandCommand(id));
    }
}