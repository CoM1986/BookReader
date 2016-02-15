using System;
using System.Windows.Input;
using Windows.Graphics.Printing;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace BookReader.ViewModels
{
    public class BookPreviewViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set { SetProperty(ref _name, value); }
        }

        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                SetProperty(ref _author, value);
            }
        }

        public byte[] Cover
        {
            get
            {
                return _cover;
            }

            set
            {
                SetProperty(ref _cover, value);
            }
        }

        private byte[] _cover;
        private string _author;

        public ICommand OpenBook { get; set; }
        private readonly INavigationService _navigationService;

        public BookPreviewViewModel(INavigationService navigationService, IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;
            OpenBook = new DelegateCommand(OpenBookAction, () => true);
        }

        private void OpenBookAction()
        {
            _navigationService.Navigate(PageTokens.BookPage, null);
            
        }
    }
}