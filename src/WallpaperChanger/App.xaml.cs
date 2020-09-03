using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Net.Http;
using System.Windows;
using WallpaperChanger.Api;
using WallpaperChanger.Api.DeviantArt.Services;
using WallpaperChanger.Json;
using WallpaperChanger.Models;

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
        }

        private IServiceProvider RegisterServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSingleton<IApi, DeviantArtApi>()
                .AddSingleton<IJsonDeserializer, JsonDeserializer>()
                .AddSingleton<HttpClient>(new HttpClient())
                .AddSingleton<Credentials>(new Credentials
                {
                    Username = "",
                    Password = ""
                })
                .AddSingleton(typeof(ILogger<>), typeof(NullLogger<>))
                .AddSingleton<MainWindow>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
