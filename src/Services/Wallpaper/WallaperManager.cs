using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WallpaperChanger.Services.Win32;

namespace WallpaperChanger.Services.Wallpaper
{
    public class WallpaperManager
    {   
        private readonly ILogger _logger;
        private readonly IBackgroundManager _backgroundManager;

        
        public WallpaperManager(ILogger<WallpaperManager> logger,IBackgroundManager backgroundManager)
        {
            _logger= logger;
            _backgroundManager = backgroundManager;           
        }
    }
}
