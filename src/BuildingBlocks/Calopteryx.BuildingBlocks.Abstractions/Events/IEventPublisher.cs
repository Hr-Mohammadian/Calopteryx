using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.BuildingBlocks.Abstractions.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}