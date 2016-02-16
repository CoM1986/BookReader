using System;
using Windows.UI.Xaml.Data;
using BookReader.ViewModels;

namespace BookReader.Converters
{
    public class ObjectToMenuItemViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value as MenuItemViewModel;
        }
    }
}