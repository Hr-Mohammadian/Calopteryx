using Calopteryx.BuildingBlocks.Abstractions.Domain.Events;
using Calopteryx.BuildingBlocks.Abstractions.Events;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Microsoft.Extensions.Logging;

namespace Calopteryx.Modules.Catalog.Core.Products.Events;

public class ProductUpdatedEventHandler : EventNotificationHandler<EntityUpdatedEvent<Product>>
{
    private readonly ILogger<ProductUpdatedEventHandler> _logger;

    public ProductUpdatedEventHandler(ILogger<ProductUpdatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityUpdatedEvent<Product> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}