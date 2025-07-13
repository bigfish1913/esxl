using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

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

        public static void SetValueByKey(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var keys = config.AppSettings.Settings.AllKeys;
            if (keys.Contains(key))
                config.AppSettings.Settings[key].Value= value;
            else
                config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified); // 保存修改

        }




    }
}
