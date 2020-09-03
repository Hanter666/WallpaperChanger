using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace WallpaperChanger.Json
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public async Task<T> Deserialize<T>(Stream data)
        {
            var result = await JsonSerializer.DeserializeAsync<T>(data);
            return result;
        }

        public T Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
