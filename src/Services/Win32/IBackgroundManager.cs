using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallpaperChanger.Models;

namespace WallpaperChanger.Services.Win32
{
    public interface IBackgroundManager
    {
        public void SetBackgroudApp(string windowName,string className = null);
        public void SetBackgroudImage<T>() where T :IImage;
        public void RemoveBackgroundApp(string windowName = null,string className = null);
        public void RemoveBackgroundApp(IntPtr appHandler);
        public void RemoveBackgroundImage();
        public void RestoreBackgroundImage();
    }
}
