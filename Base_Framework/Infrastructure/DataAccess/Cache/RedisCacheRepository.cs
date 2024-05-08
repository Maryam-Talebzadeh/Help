using Base_Framework.Domain.Core.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Base_Framework.Infrastructure.DataAccess.Cache
{
    public class RedisCacheRepository : IDistributedCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        public RedisCacheRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        #region General Set

        public async Task SetAsync<T>(string key, List<T> value, int expiratonDay, TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay),
                SlidingExpiration = slidingExpiration
            };
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), cacheOption);
        }

        public void Set<T>(string key, List<T> value, int expiratonDay, TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay),
                SlidingExpiration = slidingExpiration
            };
            _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOption);
        }

        #endregion

        #region ExpireTime Set
        public async Task SetAsync<T>(string key, List<T> value, int expiratonDay)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay)
            };
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), cacheOption);
        }
        public void Set<T>(string key, List<T> value, int expiratonDay)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expiratonDay)
            };
            _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOption);
        }

        #endregion

        #region Sliding Set
        public async Task SetAsync<T>(string key, List<T> value, TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            };
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), cacheOption);
        }
        public void Set<T>(string key, List<T> value, TimeSpan slidingExpiration)
        {
            var cacheOption = new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiration
            };
            _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOption);
        }

        #endregion

        #region Get
        public async Task<List<T>?> GetAsync<T>(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);
            if (value != null)
            {
                return JsonSerializer.Deserialize<List<T>>(value);
            }
            return default;
        }
        public List<T>? Get<T>(string key)
        {
            var value = _distributedCache.GetString(key);
            if (value != null)
            {
                return JsonSerializer.Deserialize<List<T>>(value);
            }
            return default;
        }

        #endregion
    }
}
