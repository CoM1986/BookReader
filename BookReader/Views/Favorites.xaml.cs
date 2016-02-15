using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using FB2Library;
using Prism.Windows.Mvvm;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookReader.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class FavoritesPage : SessionStateAwarePage
    {
        public FavoritesPage()
        {
            this.InitializeComponent();
        }

        private async void TestButton_OnClick(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fp = new FileOpenPicker();
            fp.ViewMode = PickerViewMode.Thumbnail;
            fp.FileTypeFilter.Add(".fb2");
            var storageFile = await fp.PickSingleFileAsync();
            var stream = await storageFile.OpenAsync(FileAccessMode.Read);
            
            XDocument fb2 = await Task.Run(() => XDocument.Load(stream.AsStreamForRead()));
            FB2File fb = new FB2File();
            fb.Load(fb2, false);
        }
    }
}
