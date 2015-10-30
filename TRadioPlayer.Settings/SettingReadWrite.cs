using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TRadioPlayer.Settings
{
    public class SettingReadWrite
    {
        private string _filePath;

        public SettingReadWrite(string filePath)
        {
            _filePath = filePath;
        }

        public Settings ReadSettings()
        {
            if (File.Exists(_filePath))
            {
                var jsonStr = File.ReadAllText(_filePath, Encoding.UTF8);
                return JsonConvert.DeserializeObject<Settings>(jsonStr);
            }
            else
            {
                return new Settings();
            }
        }

        public void WriteSettings(Settings settings)
        {
            var jsonStr = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(_filePath, jsonStr, Encoding.UTF8);
        }
    }
}
