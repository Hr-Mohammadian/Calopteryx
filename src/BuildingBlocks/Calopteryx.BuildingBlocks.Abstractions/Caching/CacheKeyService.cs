using Calopteryx.BuildingBlocks.Abstractions.Interfaces;

namespace Calopteryx.BuildingBlocks.Abstractions.Caching;

public interface ICacheKeyService : IScopedService
{
    public string GetCacheKey(string name, object id, bool includeTenantId = true);
}