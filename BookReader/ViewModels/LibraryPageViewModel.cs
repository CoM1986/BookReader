using System.Collections.Generic;
using Prism.Windows.AppModel;
using Prism.Windows.Navigation;

namespace BookReader.ViewModels
{
    public class LibraryPageViewModel : PageViewModel
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
            _books=new List<BookPreviewViewModel>();
            _books.Add(new BookPreviewViewModel(navigationService, resourceLoader));
            _books.Add(new BookPreviewViewModel(navigationService, resourceLoader));
            _books.Add(new BookPreviewViewModel(navigationService, resourceLoader));
        }
    }
}
