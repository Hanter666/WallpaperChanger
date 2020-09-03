using System.Collections.Generic;
using System.Text.Json;

namespace WallpaperChanger.Json
{
    public class JsonReader:IJsonReader
    {
        public Dictionary<string, (string,int)> Deserialize(string jsonString)
        {
            return JsonSerializer.Deserialize<Dictionary<string,(string,int)>>(jsonString);
        }
    }
}
