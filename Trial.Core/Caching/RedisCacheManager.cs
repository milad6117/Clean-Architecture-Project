using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trial.Core.Caching
{
    public class RedisCacheManager : ICacheManager
    {
        #region Field
        private readonly IDistributedCache _distributedCache;
        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        #endregion
        public T Get<T>(string key)
        {
           string data=_distributedCache.GetString(key);
            if(string.IsNullOrEmpty(data))
            {
                return default(T);
            }
            var ob=JsonConvert.DeserializeObject<T>(data);
            if(ob ==null)
                return default(T);
            return ob;
        }

        public bool IsSet(string key)
        {
            return _distributedCache.Get(key) != null;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data != null)
            {
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(cacheTime));
                var stringData = JsonConvert.SerializeObject(data);
                _distributedCache.SetString(key, stringData, options);
            }
        }
    }
}
