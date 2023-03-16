namespace Calopteryx.BuildingBlocks.Abstractions.Persistence;

public interface IConnectionStringSecurer
{
    string? MakeSecure(string? connectionString, string? dbProvider = null);
}