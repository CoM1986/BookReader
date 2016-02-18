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
        #region Fields
        private string _name;
        private byte[] _cover;
        private string _author;

        public ICommand OpenBook { get; set; }
        private readonly INavigationService _navigationService;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                SetProperty(ref _name, value);
            }
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
        #endregion

        #region Constructors
        public BookPreviewViewModel(INavigationService navigationService, IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;
            OpenBook = new DelegateCommand(OpenBookAction, () => true);
        }
        #endregion

        private void OpenBookAction()
        {
            _navigationService.Navigate(PageTokens.BookPage, null);
            
        }
    }
}