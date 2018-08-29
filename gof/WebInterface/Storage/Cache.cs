using System.Collections.Generic;

namespace WebInterface.Storage
{
    internal class Cache
    {
        // TODO: use asp.net cache mechanism
        private static Dictionary<string, object> InternalCache { get; set; }

        internal static T Get<T>(string key) where T : class
        {
            if (InternalCache.ContainsKey(key))
                return InternalCache[key] as T;
            return null;
        }

        internal static void Set<T>(string key, T objectToCache) => InternalCache[key] = objectToCache;
    }
}