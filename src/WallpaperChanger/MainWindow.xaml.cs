using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using  WallpaperChanger.Api;
using WallpaperChanger.Api.DeviantArt.Services;
using WallpaperChanger.Json;

namespace WallpaperChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApi _api;

        public MainWindow(IApi api)
        {
            InitializeComponent();
            //var d = new ApiFactory();
            //d.CreateApi<DeviantArtApiOld>();
            _api = api;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var resp = await _api.FindByTag("F9921FC4-3A0F-90A9-3625-AA8E105747AD");
        }
    }
}
