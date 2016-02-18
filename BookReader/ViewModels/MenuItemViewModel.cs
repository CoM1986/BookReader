using Prism.Windows.Mvvm;
using System;
using System.Windows.Input;

namespace BookReader.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        #region Fields
        public String DisplayName { get; set; }
        public String FontIcon { get; set; }
        public String AssignedPage { get; set; }
        public ICommand Command { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return DisplayName;
        }
        #endregion
    }
}
