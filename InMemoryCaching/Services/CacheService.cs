using System.Runtime.Caching;

namespace InMemoryCaching.Services;
public class CacheService : ICacheService
{
    private ObjectCache _memorcache = MemoryCache.Default;
    public T GetData<T>(string key)
    {
        try
        {
            T item = (T)_memorcache.Get(key);
            return item;
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public object RemoveData(string key)
    {
        bool res = true;
        try
        {
            if (!string.IsNullOrEmpty(key))
                _memorcache.Remove(key);
            else
                return false;

            return res;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        bool res = true;
        try
        {
            if (!string.IsNullOrEmpty(key))
                _memorcache.Set(key, value, expirationTime);
            else
                return false;

            return res;
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}