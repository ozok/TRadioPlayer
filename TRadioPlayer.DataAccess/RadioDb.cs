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

        private void WriteDataToFile()
        {
            var jsonStr = JsonConvert.SerializeObject(_radioInfos, Formatting.Indented);
            File.WriteAllText(_dataFilePath, jsonStr, Encoding.UTF8);
        }

        public List<RadioCategory> ReadCategoriesFromFile()
        {
            var jsonStr = File.ReadAllText(_categoriesFilePath, Encoding.UTF8);
            List<RadioCategory> result = JsonConvert.DeserializeObject<List<RadioCategory>>(jsonStr);

            return result;
        }

        public void WriteCategoriesToFile(List<RadioCategory> radioCategories)
        {
            var jsonStr = JsonConvert.SerializeObject(radioCategories, Formatting.Indented);
            File.WriteAllText(_categoriesFilePath, jsonStr, Encoding.UTF8);
        }

        public void UpdateFavState(int index)
        {
            _radioInfos[index].Faved = !_radioInfos[index].Faved;
            WriteDataToFile();
        }
    }
}
