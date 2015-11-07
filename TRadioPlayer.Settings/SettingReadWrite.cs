/*
The MIT License (MIT)

Copyright (c) 2015 ozok26@gmail.com - Okan Özcan

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

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
        private string _eqFilePath;

        public SettingReadWrite(string filePath, string eqPath)
        {
            _filePath = filePath;
            _eqFilePath = eqPath;
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

        public EqSettings ReadEqSettings()
        {
            if (File.Exists(_eqFilePath))
            {
                var jsonStr = File.ReadAllText(_eqFilePath, Encoding.UTF8);
                return JsonConvert.DeserializeObject<EqSettings>(jsonStr);
            }
            else
            {
                return new EqSettings();
            }
        }

        public void WriteEqSettings(EqSettings eqSettings)
        {
            var jsonStr = JsonConvert.SerializeObject(eqSettings, Formatting.Indented);
            File.WriteAllText(_eqFilePath, jsonStr, Encoding.UTF8); 
        }
    }
}
