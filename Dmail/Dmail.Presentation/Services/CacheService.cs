using System.Runtime.Caching;
using Dmail.Presentation.Abstractions;

namespace Dmail.Presentation.Services;

public class CacheService : ICacheService
{
    private readonly ObjectCache _memoryCache = MemoryCache.Default;

    public T GetData<T>(string key)
    {
        var item = (T)_memoryCache.Get(key);
        return item;
    }

    public void SetData<T>(string key, T value)
    {
        var expiration = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);
        
        if (!string.IsNullOrEmpty(key))
            _memoryCache.Set(key, value, new DateTime(2025,10,10));
    }

    public void RemoveData(string key)
    {
        if (!string.IsNullOrEmpty(key))
            _memoryCache.Remove(key);
    }
}