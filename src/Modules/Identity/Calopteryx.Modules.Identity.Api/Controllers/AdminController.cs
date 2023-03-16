using System.Collections.Generic;

using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Auditing;
using Calopteryx.BuildingBlocks.Abstractions.Authorization;
using Calopteryx.BuildingBlocks.Abstractions.Models;
using Calopteryx.BuildingBlocks.Infrastructures.Controller;
using Calopteryx.Modules.Identity.Core.Audits.Requests;

using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Calopteryx.Modules.Identity.Api.Controllers;

public class AdminController : VersionNeutralApiController
{

    [HttpGet("logs")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.RoleClaims)]
    [OpenApiOperation("Get audit logs of Identity module.", "")]
    public Task<List<AuditDto>> GetLogsAsync()
    {
        return Mediator.Send(new GetIdentityAuditLogsRequest());
    }
    [HttpGet("paginated-logs")]
    [MustHavePermission(CalopteryxAction.View, CalopteryxResource.RoleClaims)]
    //todo add identity audit permission later
    [OpenApiOperation("Get audit logs of Identity module.", "")]
    public async Task<IActionResult> GetPaginatedLogsAsync()
    {
        var audits = await Mediator.Send(new GetIdentityAuditLogsRequest());
        return Ok(new PaginationResponse<AuditDto>(audits, audits.Count, 1, audits.Count));
    }
}