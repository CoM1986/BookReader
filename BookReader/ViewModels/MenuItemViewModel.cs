using Prism.Windows.Mvvm;
using System;
using System.Windows.Input;

namespace BookReader.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        public String DisplayName { get; set; }
        public String FontIcon { get; set; }
        public ICommand Command { get; set; }
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
