using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using BookReader.Views;
using Prism.Events;
using Prism.Unity.Windows;

namespace BookReader.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService _navigationService;
        public ObservableCollection<MenuItemViewModel> MenuItemViewModels { get; set; }
        private MenuItemViewModel _selectedMenuItemViewModel;
        #endregion

        #region Properties
        public MenuItemViewModel SelectedMenuItemViewModel
        {
            //дважды райзится
            get { return _selectedMenuItemViewModel; }
            set
            {
                SetProperty(ref _selectedMenuItemViewModel, value, "SelectedMenuItemViewModel");
            }
        }
        #endregion

        #region Constructrs
        public MenuViewModel(INavigationService navigationService, IResourceLoader resourceLoader, IEventAggregator aggregator)
        {
            _navigationService = navigationService;
            MenuItemViewModels = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    AssignedPage = PageTokens.Library,
                    DisplayName = resourceLoader.GetString("LibraryDisplayName"),
                    FontIcon = "\uE7bc",
                    Command = new DelegateCommand(Navigate, () => true)
                },
                new MenuItemViewModel
                {
                    AssignedPage = PageTokens.Favorites,
                    DisplayName = resourceLoader.GetString("FavoritesDisplayName"),
                    FontIcon = "\uE734",
                    Command = new DelegateCommand(Navigate, () => true)
                },
            };
            
            SelectedMenuItemViewModel = MenuItemViewModels.First();
            //вот это я долго искал! вообще бы наверно как-то надо бы напрямую забиндить во фрейм SelectedItem, но пока так.
            aggregator.GetEvent<NavigationStateChangedEvent>().Subscribe(ReturnSelectedItem);
        }
        #endregion

        #region Methods
        private void ReturnSelectedItem(NavigationStateChangedEventArgs e)
        {
            //после этого попробует еще раз навигейтнуть на текущую страницу, но я думаю прризм это не пропустит
            if (e.StateChange == StateChangeType.Back)
            {
                if (e.Sender.Content is LibraryPage)
                    SelectedMenuItemViewModel = MenuItemViewModels.First(el => el.AssignedPage == PageTokens.Library);
                if (e.Sender.Content is FavoritesPage)
                    SelectedMenuItemViewModel = MenuItemViewModels.First(el => el.AssignedPage == PageTokens.Favorites);
            }
        }

        private void Navigate()
        {
            if (!_navigationService.Navigate(SelectedMenuItemViewModel.AssignedPage, null)) return;
        }
        #endregion
    }
}
