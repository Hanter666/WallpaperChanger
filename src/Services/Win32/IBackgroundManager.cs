using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperChanger.Services.Win32
{
    public interface IBackgroundManager
    {
        public void SetBackgroudApp(string windowName,string className = null);   
    }
}
