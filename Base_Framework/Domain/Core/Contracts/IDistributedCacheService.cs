﻿

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IDistributedCacheService
    {
        Task SetAsync<T>(string key, T value, int expiratonDay, TimeSpan slidingExpiration);
        Task SetListAsync<T>(string key, List<T> value, int expiratonDay, TimeSpan slidingExpiration);
        void Set<T>(string key, List<T> value, int expiratonDay, TimeSpan slidingExpiration);
        Task SetAsync<T>(string key, List<T> value, int expiratonDay);
        void Set<T>(string key, List<T> value, int expiratonDay);
        Task SetAsync<T>(string key, List<T> value, TimeSpan slidingExpiration);
        void Set<T>(string key, List<T> value, TimeSpan slidingExpiration);
        Task<List<T>?> GetListAsync<T>(string key);
        Task<T?> GetAsync<T>(string key);
        List<T>? Get<T>(string key);
    }
}
