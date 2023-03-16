
using Calopteryx.BuildingBlocks.Abstractions.Caching;


namespace Calopteryx.BuildingBlocks.Infrastructures.Caching;

public class CacheKeyService : ICacheKeyService
{

    public CacheKeyService()  {
    }

    public string GetCacheKey(string name, object id, bool includeTenantId = true)
    {
        string tenantId =  "GLOBAL";
        return $"{tenantId}-{name}-{id}";
    }
}