using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.Database
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            var Enum = ConfigurationManager.ConnectionStrings.GetEnumerator();
            while (Enum.MoveNext())
            {
                var what = Enum.Current;

            }

            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
