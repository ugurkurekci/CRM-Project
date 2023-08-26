using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

// Önbellekleme (caching) işlemlerini yöneten sınıfı içerir. 

public class CacheManager
{

    private readonly IMemoryCache _cache;

    public CacheManager(IMemoryCache cache)
    {
        _cache = cache;
    }

    public T Get<T>(string key)
    {

        T? result = _cache.Get<T>(key);
        if (result == null)
        {
            throw new KeyNotFoundException($"Key {key} not found in cache");
        }

        return result;

    }

    public void Set<T>(string key, T value)
    {
        _cache.Set(key, value);
    }

    public void Clear()
    {
        _cache.Dispose();
    }

    public void Remove(string key)
    {
        _cache.Remove(key);
    }

}