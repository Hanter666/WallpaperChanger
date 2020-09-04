using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ReactiveUI;
using System;
using System.Net.Http;
using System.Windows;
using WallpaperChanger.Api;
using WallpaperChanger.Api.DeviantArt.Services;
using WallpaperChanger.Json;
using WallpaperChanger.Models;
using WallpaperChanger.MVVM.Models;
using WallpaperChanger.Services.Json;

namespace WallpaperChanger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            _serviceProvider = RegisterServices();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        private IServiceProvider RegisterServices() => new ServiceCollection()
                .AddSingleton<IJsonDeserializer, JsonDeserializer>()
                .AddSingleton<HttpClient>(new HttpClient())
                .AddSingleton<Credentials>(new Credentials
                {
                    ClientId = "13260",
                    ClientSecret = "1f2df70af65f9a33270c2cee5aef9494"
                })
                .AddSingleton(typeof(ILogger<>), typeof(NullLogger<>))
                .AddSingleton<IApi, DeviantArtApi>()

                .AddSingleton<IReactiveObject>(new MainViewModel())

                .AddSingleton((s => new MainWindow(s.GetRequiredService<MainViewModel>())))

                .BuildServiceProvider();
    }
}
