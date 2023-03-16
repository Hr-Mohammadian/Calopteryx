using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Calopteryx.BuildingBlocks.Abstractions.Auditing;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence.Context;
using Calopteryx.Modules.Identity.Core.DAL;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Calopteryx.Modules.Identity.Core.Audits.Services;


public class IdentityAuditService : IIdentityAuditService
{
    private readonly IdentitiesDbContext _context;

    public IdentityAuditService(IdentitiesDbContext context) => _context = context;

    public async Task<List<AuditDto>> GetIdentityTrailsAsync()
    {
        var trails = await _context.AuditTrails
        .OrderByDescending(a => a.DateTime)
        .Take(250)
        .ToListAsync();

        return trails.Adapt<List<AuditDto>>();
    }
}