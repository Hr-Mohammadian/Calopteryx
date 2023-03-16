using Calopteryx.BuildingBlocks.Abstractions.Events;
using Calopteryx.BuildingBlocks.Abstractions.Interfaces;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence.Configuration;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence.Context;
using Calopteryx.Modules.Catalog.Core.Brands.Entities;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calopteryx.Modules.Catalog.Core.DAL;

public class CatalogDbContext: BaseDbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options, ICurrentUser currentUser, ISerializerService serializer,  IEventPublisher events)
        : base(options, currentUser, serializer,  events)
    {
    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);

    }
}