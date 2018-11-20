using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadingNet.Cache
{
    public interface ICache
    {
        void Clear();
        object Get(string key);
        void Add(string key,object value);
        void Add(string key, object value, TimeSpan timeToLive);
        void Remove(string key);
        int Count { get; }
        ICollection Keys { get; }

    }
}
