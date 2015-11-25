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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TRadioPlayer.DataAccess
{
    public class RadioDb
    {
        private string _dataFilePath;
        private string _categoriesFilePath;
        private List<RadioInfo> _radioInfos; 

        //public string[] RadioCategories = new[] { "All", "50s, 60s & 70s", "80s & 90s", "Alternative", "Ambient & Chill", "Anime & Asian", "Black, Rap & HipHop", "Blues & Love", "Classical", "Club", "Children", "Country", "Dance & Pop", "Electronic", "Folk & Latino", "Gothic", "Hits", "Jazz & Soul", "Reggae", "Retro", "Rock & Metal", "Talk & News", "Schlager", "Soundtrack & Movie", "Season" };

        /// <summary>
        /// radio db
        /// </summary>
        /// <param name="dataFilePath">where stations are kept</param>
        /// <param name="categoriesFilePath">where station categories are kept</param>
        public RadioDb(string dataFilePath, string categoriesFilePath)
        {
            _dataFilePath = dataFilePath;
            _categoriesFilePath = categoriesFilePath;
            _radioInfos = ReadDataFromFile();
            for (int i = 0; i < _radioInfos.Count; i++)
            {
                _radioInfos[i].Index = i;
            }
        }

        /// <summary>
        /// returns a list of radio stations
        /// </summary>
        /// <param name="categoryId">radio station category</param>
        /// <param name="onlyFaved">if only favourited stations or all of them</param>
        /// <returns></returns>
        public List<RadioInfo> GetRadioStationsAccordingToCategory(int categoryId = 0, bool onlyFaved = false)
        {
            List<RadioInfo> result;
            // this means favourites are selected
            if (onlyFaved)
            {
                result = _radioInfos.Where(c => c.Faved).ToList();
            }
            else
            {
                // if categoryId is equal to 0, it means all
                result = categoryId != 0 ? _radioInfos.Where(c => c.CategoryId == categoryId).ToList() : _radioInfos;
            }

            // order results according to station title
            result = result.OrderBy(r => r.Title).ToList();
            // give index to each station
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Index = i;
            }
            return result;    
        }

        /// <summary>
        /// adds a single radio station to the list
        /// </summary>
        /// <param name="radioInfo">radio station</param>
        public void Add(RadioInfo radioInfo)
        {
            _radioInfos.Add(radioInfo);
            WriteDataToFile();
        }

        /// <summary>
        /// reads radio stations from a json file
        /// information is stored on a list which is
        /// used in other read/write operations.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="onlyFaved"></param>
        /// <returns></returns>
        private List<RadioInfo> ReadDataFromFile(int categoryId = 0, bool onlyFaved = false)
        {
            var jsonStr = File.ReadAllText(_dataFilePath, Encoding.UTF8);
            List<RadioInfo> result = JsonConvert.DeserializeObject<List<RadioInfo>>(jsonStr);

            if (onlyFaved)
            {
                result = result.Where(c => c.Faved).ToList();
            }
            else
            {
                if (categoryId != 0)
                {
                    result = result.Where(c => c.CategoryId == categoryId).ToList();
                }
            }
            return result.OrderBy(c => c.Title).ToList();
        }

        /// <summary>
        /// writes radio stations master list to a json file
        /// </summary>
        private void WriteDataToFile()
        {
            var jsonStr = JsonConvert.SerializeObject(_radioInfos, Formatting.Indented);
            File.WriteAllText(_dataFilePath, jsonStr, Encoding.UTF8);
        }

        /// <summary>
        /// read radio station categories from a json file
        /// </summary>
        /// <returns></returns>
        public List<RadioCategory> ReadCategoriesFromFile()
        {
            var jsonStr = File.ReadAllText(_categoriesFilePath, Encoding.UTF8);
            List<RadioCategory> result = JsonConvert.DeserializeObject<List<RadioCategory>>(jsonStr);

            return result;
        }

        /// <summary>
        /// writes radio station categories to a json file
        /// </summary>
        /// <param name="radioCategories"></param>
        public void WriteCategoriesToFile(List<RadioCategory> radioCategories)
        {
            var jsonStr = JsonConvert.SerializeObject(radioCategories, Formatting.Indented);
            File.WriteAllText(_categoriesFilePath, jsonStr, Encoding.UTF8);
        }

        /// <summary>
        /// reverses a radio station's favourite state
        /// </summary>
        /// <param name="radioInfo"></param>
        public void UpdateFavState(RadioInfo radioInfo)
        {
            RadioInfo radioInfo1 = _radioInfos.FirstOrDefault(r => r == radioInfo);
            if (radioInfo1 != null)
            {
                radioInfo1.Faved = !radioInfo1.Faved;
                WriteDataToFile();
            }
        }
    }
}
