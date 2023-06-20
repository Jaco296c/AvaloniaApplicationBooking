using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.Configuration
{
    public class Config
    {
        public static ObservableCollection<ConfigProp> InstanceOfConfigProp { get; set; }
        private ObservableCollection<ConfigProp> customProperties = new ObservableCollection<ConfigProp>();

        public Config()
        {
            customProperties.Add(new ConfigProp("Username/LoginMaxLength", 21)); // 0
            customProperties.Add(new ConfigProp("PasswordMaxLength", 30)); // 1
            customProperties.Add(new ConfigProp("FirstnameMaxLength", 200)); // 2
            customProperties.Add(new ConfigProp("LastnameMaxLength", 200)); // 3
            customProperties.Add(new ConfigProp("MailMaxLength", 320)); // 4
            customProperties.Add(new ConfigProp("PhoneNumberMaxLength", 20)); // 5
        }
        public void SaveConfig()
        {
            var saveCustomproperties = JsonConvert.SerializeObject(customProperties, Formatting.Indented);
            File.WriteAllText("CustomProperties.json", saveCustomproperties);

        }
        public void LoadConfig()
        {
            string fileloadProperties = File.ReadAllText("CustomProperties.json");
            var FLT = JsonConvert.DeserializeObject<ObservableCollection<ConfigProp>>(fileloadProperties);
            if (FLT != null)
            {
                customProperties = FLT;
            }
            InstanceOfConfigProp = customProperties;
        }
    }
}
