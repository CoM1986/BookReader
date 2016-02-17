using System;
using System.Collections.Generic;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;

namespace BookReader.ViewModels
{
    public class LibraryPageViewModel : PageViewModel, INavigationAware
    {
        
        IList<BookPreviewViewModel> _books;

        public IList<BookPreviewViewModel> Books
        {
            get
            {
                return _books;
            }

            set
            {
                SetProperty(ref _books, value);
            }
        }

        public LibraryPageViewModel(INavigationService navigationService, IResourceLoader resourceLoader)
        {
            PageToken = PageTokens.Library;
            _books = new List<BookPreviewViewModel>
            {
                new AddNewBookViewModel(navigationService, resourceLoader),
                new BookPreviewViewModel(navigationService, resourceLoader),
                new BookPreviewViewModel(navigationService, resourceLoader),
                new BookPreviewViewModel(navigationService, resourceLoader)
            };
        }



    }
}
