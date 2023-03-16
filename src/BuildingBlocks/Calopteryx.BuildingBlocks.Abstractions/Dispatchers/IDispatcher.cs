using Calopteryx.BuildingBlocks.Abstractions.Commands;
using Calopteryx.BuildingBlocks.Abstractions.Events;
using Calopteryx.BuildingBlocks.Abstractions.Queries;

namespace Calopteryx.BuildingBlocks.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}