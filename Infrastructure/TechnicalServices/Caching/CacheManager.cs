using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.TechnicalServices.Caching;


public class CacheManager : ICacheManager
{

    private readonly IMemoryCache _memoryCache;

    public CacheManager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Add(string key, object value)
    {
        _memoryCache.Set(key, value);
    }

    public void Add(string key, object value, int cacheTime)
    {
        _memoryCache.Set(key, value, TimeSpan.FromMinutes(cacheTime));
    }

    public void Clear()
    {
        _memoryCache.Dispose();
    }

    public bool Contains(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

}