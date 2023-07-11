using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Core.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        #region Field
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        #endregion
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public bool IsSet(string key)
        {
            return _memoryCache.TryGetValue(key, out object _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void Set(string key, object data, int cacheTime)
        {
           if(data!=null)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions();
                cacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime);
                _memoryCache.Set(key,data,cacheEntryOptions);
            }
        }
    }
}
