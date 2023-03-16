namespace Calopteryx.BuildingBlocks.Abstractions.Events;

public interface IEventDispatcher
{
    // Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
        
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent;
}