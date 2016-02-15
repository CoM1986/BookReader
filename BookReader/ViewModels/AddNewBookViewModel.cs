using System.Windows.Input;
using Windows.Storage.Pickers;
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

        private void OpenFileDialog()
        {
            FileOpenPicker fp = new FileOpenPicker();
            fp.FileTypeFilter.Add(".fb2");
            fp.ViewMode = PickerViewMode.Thumbnail;
            var file = fp.PickSingleFileAsync();
        }
    }
}