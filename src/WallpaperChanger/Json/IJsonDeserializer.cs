using System.IO;
using System.Threading.Tasks;

namespace WallpaperChanger.Json
{
    public interface IJsonDeserializer
    {
        Task<T> Deserialize<T>(Stream data);

        T Deserialize<T>(string data);
    }
}
