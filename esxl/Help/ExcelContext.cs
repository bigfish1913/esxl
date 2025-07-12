using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace esxl.Help
{
    internal class ExcelContext
    {
        public static ExcelFile ContextFile { get; set; }
        private static ExcelContext? excelContext;
        private static Dictionary<string, object>? cache;

        public static ExcelContext InitContext(string filePath)
        {
            ContextFile = new ExcelFile(filePath);
            excelContext = new ExcelContext();
            cache = new Dictionary<string, object>();
            return excelContext;
        }

        public static T LoadData<T>(string key, Func<T>  loadFunc) where T : class
        {
            if ( cache == null)
            {
                cache= new Dictionary<string, object>();
            }
            if ( cache.ContainsKey(key))
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
