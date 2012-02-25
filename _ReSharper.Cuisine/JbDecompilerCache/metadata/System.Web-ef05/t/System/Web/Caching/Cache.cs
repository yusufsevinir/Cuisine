// Type: System.Web.Caching.Cache
// Assembly: System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Web.dll

using System;
using System.Collections;
using System.Security.Permissions;

namespace System.Web.Caching
{
    public sealed class Cache : IEnumerable
    {
        public static readonly DateTime NoAbsoluteExpiration;
        public static readonly TimeSpan NoSlidingExpiration;

        [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
        public Cache();

        public int Count { get; }
        public object this[string key] { get; set; }
        public long EffectivePrivateBytesLimit { get; }
        public long EffectivePercentagePhysicalMemoryLimit { get; }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator();

        #endregion

        public IDictionaryEnumerator GetEnumerator();
        public object Get(string key);
        public void Insert(string key, object value);
        public void Insert(string key, object value, CacheDependency dependencies);
        public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration);
        public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
        public void Insert(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemUpdateCallback onUpdateCallback);
        public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);
        public object Remove(string key);
    }
}
