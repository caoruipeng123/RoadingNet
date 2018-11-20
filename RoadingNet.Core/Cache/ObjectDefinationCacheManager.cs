using RoadingNet.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RoadingNet.Cache
{
    public sealed class ObjectDefinationCacheManager : IDisposable
    {
        private static Dictionary<string, object> definationCache;
        static ObjectDefinationCacheManager()
        {
            definationCache = new Dictionary<string, object>();
        }
        public int Count
        {
            get
            {
                return definationCache.Count;
            }
        }

        public ICollection Keys
        {
            get
            {
                return definationCache.Keys;
            }
        }

        public void Add(string name, IObjectDefination value)
        {
            definationCache.Add(name, value);
        }

        public void Add(string name, IObjectDefination value, TimeSpan timeToLive)
        {
            definationCache.Add(name, value);
        }

        public void Clear()
        {
            definationCache.Clear();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object Get(string name)
        {
            object value = null;
            definationCache.TryGetValue(name, out value);
            return value;
        }

        public void Remove(string name)
        {
            definationCache.Remove(name);
        }
    }
}
