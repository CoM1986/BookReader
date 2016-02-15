using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace BookReader.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _canNavigateToLibrary = false;
        private bool _canNavigateToFavorites = true;
        public ObservableCollection<MenuItemViewModel> Commands { get; set; }

        public MenuViewModel(INavigationService navigationService, IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;
            Commands = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    DisplayName = resourceLoader.GetString("LibraryDisplayName"),
                    FontIcon ="\uE7bc",
                    Command = new DelegateCommand(NavigateToLibrary, CanNavigateToLibrary)
                },
                new MenuItemViewModel
                {
                    DisplayName = resourceLoader.GetString("FavoritesDisplayName"),
                    FontIcon ="\uE734",
                    Command = new DelegateCommand(NavigateToFavorites, CanNavigateToFavorites)
                },
            };
        }

        private void NavigateToLibrary()
        {
            if (!CanNavigateToLibrary()) return;
            if (!_navigationService.Navigate(PageTokens.Library, null)) return;
            _canNavigateToLibrary = false;
            _canNavigateToFavorites = true;
            RaiseCanExecuteChanged();
        }

        private void RaiseCanExecuteChanged()
        {
            foreach (var delegateCommand in Commands.Select(item => item.Command as DelegateCommand))
            {
                delegateCommand?.RaiseCanExecuteChanged();
            }
        }

        private bool CanNavigateToLibrary()
        {
            return _canNavigateToLibrary;
        }

        private void NavigateToFavorites()
        {
            if (!CanNavigateToFavorites()) return;
            if (!_navigationService.Navigate(PageTokens.Favorites, null)) return;
            _canNavigateToLibrary = true;
            _canNavigateToFavorites = false;
            RaiseCanExecuteChanged();
        }

        private bool CanNavigateToFavorites()
        {
            return _canNavigateToFavorites;
        }
    }
}
