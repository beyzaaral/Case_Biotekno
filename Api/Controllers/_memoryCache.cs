using Entities.Entity;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Api.Controllers
{
    public class MemoryCacheService
    {
        private readonly MemoryCache _cache;

        public MemoryCacheService()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public T Get<T>(string cacheKey)
        {
            if (_cache.TryGetValue(cacheKey, out T cachedValue))
            {
                return cachedValue;
            }
            return default(T);
        }

        public void Set<T>(string cacheKey, T value, DateTimeOffset absoluteExpiration)
        {
            _cache.Set(cacheKey, value, absoluteExpiration);
        }
    }

}