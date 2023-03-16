using Calopteryx.BuildingBlocks.Abstractions.Events;

namespace Calopteryx.BuildingBlocks.Abstractions.Messaging;

public interface IMessageBroker
{
    Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
}