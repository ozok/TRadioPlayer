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

        public List<RadioInfo> Get(int categoryId = 0, bool onlyFaved = false)
        {
            List<RadioInfo> result;

            if (onlyFaved)
            {
                result = _radioInfos.Where(c => c.Faved).ToList();
            }
            else
            {
                result = categoryId != 0 ? _radioInfos.Where(c => c.CategoryId == categoryId).ToList() : _radioInfos;
            }
            return result.OrderBy(c => c.Title).ToList();    
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
