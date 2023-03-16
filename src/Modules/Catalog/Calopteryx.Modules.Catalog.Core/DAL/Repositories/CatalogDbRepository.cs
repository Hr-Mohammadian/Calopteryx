using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Calopteryx.BuildingBlocks.Abstractions.Domain.Contracts;
using Calopteryx.BuildingBlocks.Abstractions.Persistence;
using Calopteryx.BuildingBlocks.Infrastructures.Persistence.Context;
using Mapster;

namespace Calopteryx.Modules.Catalog.Core.DAL.Repositories;

// Inherited from Ardalis.Specification's RepositoryBase<T>
public class CatalogDbRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    public CatalogDbRepository(CatalogDbContext dbContext)
        : base(dbContext)
    {
    }

    // We override the default behavior when mapping to a dto.
    // We're using Mapster's ProjectToType here to immediately map the result from the database.
    // This is only done when no Selector is defined, so regular specifications with a selector also still work.
    protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();
}