using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Auditing;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.Modules.Identity.Core.Audits.Services;
using MediatR;

namespace Calopteryx.Modules.Identity.Core.Audits.Requests;

public class GetIdentityAuditLogsRequest : IRequest<List<AuditDto>>
{
}

public class GetIdentityAuditLogsRequestHandler : IRequestHandler<GetIdentityAuditLogsRequest, List<AuditDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IIdentityAuditService _auditService;

    public GetIdentityAuditLogsRequestHandler(ICurrentUser currentUser, IIdentityAuditService auditService) =>
        (_currentUser, _auditService) = (currentUser, auditService);

    public Task<List<AuditDto>> Handle(GetIdentityAuditLogsRequest request, CancellationToken cancellationToken) =>
        _auditService.GetIdentityTrailsAsync();
}