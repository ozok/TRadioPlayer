using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRadioPlayer.Settings
{
    public class Settings
    {
        public int RadioCategory { get; set; }
        public int VolumeLevel { get; set; }

        public Settings()
        {
            RadioCategory = 0;
            VolumeLevel = 50;
        }
    }
}
