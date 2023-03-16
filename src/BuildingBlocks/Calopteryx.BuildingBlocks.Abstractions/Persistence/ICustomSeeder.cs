namespace Calopteryx.BuildingBlocks.Abstractions.Persistence;

public interface ICustomSeeder
{
    Task InitializeAsync(CancellationToken cancellationToken);
}