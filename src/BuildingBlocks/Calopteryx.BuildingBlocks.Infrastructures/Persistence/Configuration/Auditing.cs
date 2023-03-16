using Calopteryx.BuildingBlocks.Abstractions.Auditing;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calopteryx.BuildingBlocks.Infrastructures.Persistence.Configuration;

public class AuditTrailConfig : IEntityTypeConfiguration<Trail>
{
    public void Configure(EntityTypeBuilder<Trail> builder) =>
        builder
            .ToTable("AuditTrails", SchemaNames.Auditing);
}