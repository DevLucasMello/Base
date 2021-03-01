using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    internal class WebConfigHelper
    {

        public static string Get(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static int? GetInt(string key)
        {
            var data = System.Configuration.ConfigurationManager.AppSettings[key];
            int result = 0;
            if(int.TryParse(data, out result))
            {
                return result;
            }
            return null;
        }

        public static decimal? GetDecimal(string key)
        {
            var data = System.Configuration.ConfigurationManager.AppSettings[key];
            decimal result = 0;
            if (decimal.TryParse(data, out result))
            {
                return result;
            }
            return null;
        }

        public static bool? GetBoolean(string key)
        {
            var data = System.Configuration.ConfigurationManager.AppSettings[key];
            bool result = false;
            if (bool.TryParse(data, out result))
            {
                return result;
            }
            return null;
        }

    }
}
