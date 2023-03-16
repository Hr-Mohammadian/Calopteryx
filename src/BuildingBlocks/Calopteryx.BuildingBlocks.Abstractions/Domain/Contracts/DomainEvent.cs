using Calopteryx.BuildingBlocks.Abstractions.Events;

namespace Calopteryx.BuildingBlocks.Abstractions.Domain.Contracts;

public abstract class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}