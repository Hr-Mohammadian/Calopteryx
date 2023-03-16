using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Auditing;

namespace Calopteryx.Modules.Identity.Core.Audits.Services;


public interface IIdentityAuditService : IAuditService
{
    Task<List<AuditDto>> GetIdentityTrailsAsync();
}