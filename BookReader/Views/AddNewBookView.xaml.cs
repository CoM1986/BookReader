using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BookReader.Annotations;
using BookReader.ViewModels;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BookReader.Views
{
    public sealed partial class AddNewBookView : UserControl, INotifyPropertyChanged
    {
        public AddNewBookView()
        {
            this.InitializeComponent();
            this.DataContextChanged += AddNewBookView_DataContextChanged;
        }

        private void AddNewBookView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            OnPropertyChanged(nameof(ConcreteDataContext));
        }
        public AddNewBookViewModel ConcreteDataContext => DataContext as AddNewBookViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
