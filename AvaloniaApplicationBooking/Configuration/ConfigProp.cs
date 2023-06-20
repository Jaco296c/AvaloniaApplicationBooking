using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.Configuration
{
    public class ConfigProp
    {
        public ConfigProp(string name, double maxValue)
        {
            Name = name;
            MaxValue = maxValue;
        }

        public string Name { get; private set; }
        public double MaxValue { get; set; }


    }
}
