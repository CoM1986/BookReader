using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;
using FB2Library;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;

namespace BookReader.ViewModels
{
    public class AddNewBookViewModel : BookPreviewViewModel
    {
        public ICommand OpenFile { get; set; }

        public AddNewBookViewModel(INavigationService navigationService, IResourceLoader resourceLoader)
            :base(navigationService, resourceLoader)
        {
            OpenFile = new DelegateCommand(OpenFileDialog, () => true);
        }

        private async void OpenFileDialog()
        {
            FileOpenPicker fp = new FileOpenPicker();
            fp.FileTypeFilter.Add(".fb2");
            fp.ViewMode = PickerViewMode.Thumbnail;
            var file = await fp.PickSingleFileAsync();
            if (file != null)
            {
                var stream = await file.OpenAsync(FileAccessMode.Read);
                XDocument doc = await Task.Run(() => XDocument.Load(stream.AsStreamForRead()));
                FB2File fb2File = new FB2File();
                fb2File.Load(doc, false);
            }
        }
    }
}