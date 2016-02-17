using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using Prism.Windows.Navigation;

namespace BookReader.ViewModels
{
    public class PageViewModel : ViewModelBase, INavigationAware
    {
        public String PageToken { get; set; }
    }
}
