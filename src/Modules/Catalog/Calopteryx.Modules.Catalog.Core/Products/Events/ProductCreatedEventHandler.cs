using Calopteryx.BuildingBlocks.Abstractions.Domain.Events;
using Calopteryx.BuildingBlocks.Abstractions.Events;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Microsoft.Extensions.Logging;

namespace Calopteryx.Modules.Catalog.Core.Products.Events;

public class ProductCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Product>>
{
    private readonly ILogger<ProductCreatedEventHandler> _logger;

    public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Product> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}