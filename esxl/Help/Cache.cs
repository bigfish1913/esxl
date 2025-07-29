using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esxl.Help
{
    internal class Cache
    {
        private static Dictionary<string, object>? cache;
 
        public static T LoadData<T>(string key, Func<T> loadFunc) where T : class
        {
            if (cache == null)
            {
                cache = new Dictionary<string, object>();
            }
            if (cache.ContainsKey(key))
            {
                return (T)cache[key];
            }
            var data = loadFunc();
            if (data != null)
            {
                cache.Add(key, data);
            }
            return data;
        }
    }
}
