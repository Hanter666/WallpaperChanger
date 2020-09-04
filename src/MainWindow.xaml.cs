using Microsoft.Extensions.Logging.Abstractions;
using ReactiveUI;
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
        public MainWindow(IReactiveObject viewModel)
        {           
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
