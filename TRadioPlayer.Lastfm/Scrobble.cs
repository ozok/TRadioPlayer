using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lpfm.LastFmScrobbler;

namespace TRadioPlayer.Lastfm
{
    public class Scrobble
    {
        public string ErrorMessage { get; set; }
        public Scrobble(string trackData)
        {
            List<string> trackDataList = trackData.Split('-').ToList();
            if (trackDataList.Count > 0)
            {
                string artist = trackDataList[0];
                string title = string.Empty;
                for (int i = 1; i < trackDataList.Count; i++)
                {
                    title += trackDataList[i];
                }

                Scrobbler scrobbler = new Scrobbler("0a5674077da2782718075412eab00800", "56668ad9e4293be48def8f5ab1a6c658");
                Track track = new Track {ArtistName = artist, TrackName = title};
                ScrobbleResponse response = scrobbler.Scrobble(track);
                ErrorMessage = response.Exception.Message + " " + response.ErrorCode.ToString();
            }
            else
            {
                ErrorMessage = trackDataList.Count.ToString();
            }       
        }
    }
}
