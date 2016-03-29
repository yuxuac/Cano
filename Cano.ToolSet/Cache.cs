using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Cano
{
    public class Cache
    {
        /// <summary>
        /// Get item using cache, will refresh cache after 1 day.
        /// </summary>
        /// <typeparam name="T">Type of item to get</typeparam>
        /// <param name="cacheKey">Cache key</param>
        /// <param name="function">Function to get the item if not available in cache</param>
        /// <returns>Retrieved object</returns>
        public static T UsingCache<T>(string cacheKey, Func<T> function)
        {
            object cachedObject = null;
            if (HttpContext.Current != null)
            {
                cachedObject = HttpContext.Current.Cache.Get(cacheKey);
            }
            else
            {
                cachedObject = MemoryCache.Default.Get(cacheKey);
            }

            if (cachedObject != null)
            {
                if (cachedObject == DBNull.Value)
                {
                    return default(T);
                }

                try
                {
                    return (T)cachedObject;
                }
                catch
                {
                    // In this case continue and get result from function
                }
            }

            T result = function();

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Cache.Add(
                    cacheKey,
                    (object)result ?? DBNull.Value,
                    new CacheDependency(HttpContext.Current.Server.MapPath("~/bin")),
                    DateTime.Now.AddDays(1),
                    TimeSpan.Zero,
                    System.Web.Caching.CacheItemPriority.Default,
                    null);
            }
            else
            {
                MemoryCache.Default.Add(
                    cacheKey,    
                    (object)result ?? DBNull.Value,
                    new CacheItemPolicy()
                    {
                        AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddDays(1))
                    });
            }

            return result;
        }
    }
}
