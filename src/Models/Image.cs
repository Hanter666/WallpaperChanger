using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WallpaperChanger.Models
{
    public interface IImage
    {
        public string Url { get; set; }
        public (int Width,int Height) Size { get; set; }
        public BitmapImage BitmapImage { get; set; }
    }
    public class Image : IImage
    {
        public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public (int Width, int Height) Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BitmapImage BitmapImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
