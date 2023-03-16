

namespace Calopteryx.BuildingBlocks.Abstractions.Persistence;

public interface IDatabaseInitializer
{
    Task InitializeDatabasesAsync(CancellationToken cancellationToken);
}