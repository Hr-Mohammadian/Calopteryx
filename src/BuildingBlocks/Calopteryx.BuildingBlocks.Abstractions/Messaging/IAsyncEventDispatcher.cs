using Calopteryx.BuildingBlocks.Abstractions.Events;

namespace Calopteryx.BuildingBlocks.Abstractions.Messaging;

public interface IAsyncEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent;
}