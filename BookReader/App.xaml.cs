using System;
using System.IO;
using Microsoft.Practices.Unity;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using BookReader.Model;
using Prism.Windows.AppModel;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace BookReader
{
    /// <summary>
    /// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
    /// </summary>
    sealed partial class App
    {
        /// <summary>
        /// Инициализирует одноэлементный объект приложения.  Это первая выполняемая строка разрабатываемого
        /// кода; поэтому она является логическим эквивалентом main() или WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        protected override UIElement CreateShell(Frame rootFrame)
        {
            var shell = Container.Resolve<AppShell>();
            shell.SetContentFrame(rootFrame);
            
            return shell;
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            String path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            Container.RegisterInstance<IResourceLoader>(new ResourceLoaderAdapter(new Windows.ApplicationModel.Resources.ResourceLoader()));
            return base.OnInitializeAsync(args);
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            //NavigationService.Navigate(PageTokens.Library, null);
            
            return Task.FromResult(true);
        }
    }
}
