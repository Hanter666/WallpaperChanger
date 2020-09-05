using System.Threading.Tasks;
using WallpaperChanger.Models;

namespace WallpaperChanger.Api
{
    public interface IApi
    {
        public Task<IImage[]> FindByTag(string tag);
    }
}
