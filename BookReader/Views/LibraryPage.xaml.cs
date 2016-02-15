using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using BookReader.Annotations;
using BookReader.ViewModels;
using FB2Library;
using Prism.Windows.Mvvm;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookReader.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class LibraryPage : SessionStateAwarePage
    {
        public LibraryPage()
        {
            this.InitializeComponent();
        }

        private async void OpenFileTest_OnClick(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fp = new FileOpenPicker();
            fp.ViewMode = PickerViewMode.Thumbnail;
            fp.FileTypeFilter.Add(".fb2");
            var storageFile = await fp.PickSingleFileAsync();
            XDocument fb2 = XDocument.Load(storageFile.Path);
            FB2File fb = new FB2File();
            fb.Load(fb2, false);
        }
    }
}
