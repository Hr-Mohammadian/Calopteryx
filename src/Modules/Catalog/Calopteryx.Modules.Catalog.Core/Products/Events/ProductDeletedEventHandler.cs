using Calopteryx.BuildingBlocks.Abstractions.Domain.Events;
using Calopteryx.BuildingBlocks.Abstractions.Events;
using Calopteryx.Modules.Catalog.Core.Products.Entities;
using Microsoft.Extensions.Logging;

namespace Calopteryx.Modules.Catalog.Core.Products.Events;

public class ProductDeletedEventHandler : EventNotificationHandler<EntityDeletedEvent<Product>>
{
    private readonly ILogger<ProductDeletedEventHandler> _logger;

    public ProductDeletedEventHandler(ILogger<ProductDeletedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityDeletedEvent<Product> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}