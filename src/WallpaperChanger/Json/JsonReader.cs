using System.Collections.Generic;
using System.Text.Json;

namespace WallpaperChanger.Json
{
    public class JsonReader:IJsonReader
    {
        public Dictionary<string, string> Deserialize(string jsonString)
        {
            return JsonSerializer.Deserialize<Dictionary<string,string>>(jsonString);
        }
    }
}
