using Calopteryx.BuildingBlocks.Abstractions.Domain.Contracts;

namespace Calopteryx.BuildingBlocks.Abstractions.Domain.Events;

public static class EntityDeletedEvent
{
    public static EntityDeletedEvent<TEntity> WithEntity<TEntity>(TEntity entity)
        where TEntity : IEntity
        => new(entity);
}

public class EntityDeletedEvent<TEntity> : DomainEvent
    where TEntity : IEntity
{
    internal EntityDeletedEvent(TEntity entity) => Entity = entity;

    public TEntity Entity { get; }
}
