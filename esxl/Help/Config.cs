using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esxl.Help
{
    internal class Config
    {

        public static string? GetValueByKey(string key)
        {
            var keys= ConfigurationManager.AppSettings.AllKeys;
            if (keys.Contains(key))
                return ConfigurationManager.AppSettings[key];

            return null;
        }
    }
}
