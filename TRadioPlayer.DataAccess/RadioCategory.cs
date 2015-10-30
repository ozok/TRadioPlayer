using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRadioPlayer.DataAccess
{
    public class RadioCategory
    {
        public string Title { get; set; }
        public int LastPlayedStationIndex { get; set; }

        public RadioCategory()
        {
            LastPlayedStationIndex = -1;
        }
    }
}
