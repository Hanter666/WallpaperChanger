namespace WallpaperChanger.Api
{
    public interface IApi
    {
        public Image[] FindByTag(string tag);
    }
}
