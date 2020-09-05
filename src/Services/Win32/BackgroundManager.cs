using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WallpaperChanger.Services.Win32
{
    public class BackgroundManager : IBackgroundManager
    {
        private readonly ILogger _logger;
        private const string _progmanWindowName = "Progman";
        private const string _workerWWindowName = "WorkerW";
        private const string _DefViewWindowName="SHELLDLL_DefView";
        private IntPtr _progmanWindow;
        private IntPtr _workerwWindow;

        public BackgroundManager(ILogger logger)
        {
            _logger = logger;
            Initialise();
        }       
        private IntPtr GetProgmanWindowPtr()
        {
            _logger.LogDebug("Trying find Progman window");
            IntPtr progmanWindow = WinApi.FindWindowA(_progmanWindowName,null);
            if (progmanWindow == IntPtr.Zero)
            {
                _logger.LogError("Progman is {0}",progmanWindow);
            }
            return progmanWindow;
        }

        private void CreateWorkerWindow()
        {
            _logger.LogDebug("Create WorkerW windows");
            uint WM_SPAWN_WORKER = 0x052C;
            IntPtr wParam = (IntPtr)0x0000000D;
            WinApi.SendMessage(_progmanWindow,WM_SPAWN_WORKER,wParam,(IntPtr)0);
            WinApi.SendMessage(_progmanWindow,WM_SPAWN_WORKER,wParam,(IntPtr)1);

            WinApi.EnumWindows(new WinApi.EnumWindowsProc((IntPtr tophandle,ref IntPtr topparamhandle) =>
            {
                IntPtr p = WinApi.FindWindowEx(tophandle,IntPtr.Zero,_DefViewWindowName,null);
                if (p != IntPtr.Zero)
                {
                    // Gets the WorkerW Window after the current one.
                    _workerwWindow = WinApi.FindWindowEx(IntPtr.Zero,tophandle,_workerWWindowName,null);
                }
                return true;
            }), IntPtr.Zero);
        }

        private void Initialise()
        {
            _progmanWindow = GetProgmanWindowPtr();
            CreateWorkerWindow();
        }
        public void SetBackgroudApp(string windowName,string className = null)
        {
            IntPtr targetWindow = WinApi.FindWindowA(className,windowName);
            if (targetWindow!=IntPtr.Zero)
            {
               WinApi.SetParent(targetWindow,_workerwWindow); 
            }
        }
    }
}
