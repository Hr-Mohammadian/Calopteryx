using Calopteryx.BuildingBlocks.Abstractions.Auditing;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calopteryx.Modules.Identity.Core.DAL.Configurations;

public class AuditTrailConfig : IEntityTypeConfiguration<Trail>
{
    public void Configure(EntityTypeBuilder<Trail> builder) =>
        builder
            .ToTable("AuditTrails", SchemaNames.Identity);
}