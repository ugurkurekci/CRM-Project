namespace Infrastructure.TechnicalServices.Caching;

public interface ICacheManager
{
    void Add(string key, object value);
    void Add(string key, object value, int cacheTime);
    bool Contains(string key);
    T Get<T>(string key);
    void Remove(string key);
    void Clear();
}