using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WallpaperChanger.Json;

namespace WallpaperChanger.Services.Json
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
