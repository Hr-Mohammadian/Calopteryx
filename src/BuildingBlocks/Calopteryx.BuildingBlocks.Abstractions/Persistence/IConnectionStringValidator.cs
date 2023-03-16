namespace Calopteryx.BuildingBlocks.Abstractions.Persistence;

public interface IConnectionStringValidator
{
    bool TryValidate(string connectionString, string? dbProvider = null);
}