using System.Collections.Generic;

namespace WallpaperChanger.Api
{
    public class ApiFactory
    {
        private readonly Dictionary<string, IApi> _apis = new Dictionary<string, IApi>();

        public T CreateApi<T>() where T : IApi, new()
        {
            var key = nameof(T);
            if (!_apis.TryGetValue(key, out var api))
            {
                api = new T();
                _apis.Add(key, api);
            }
            
            return (T)api;
        }
    }
}
