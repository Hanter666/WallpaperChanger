using System.Threading.Tasks;

namespace WallpaperChanger.Api
{
    public interface IApi
    {
        public Task<Image[]> FindByTag(string tag);
    }
}
