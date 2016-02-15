using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BookReader.ViewModels;

namespace BookReader.TemplateSelectors
{
    public class BookPreviewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BookPreviewTemplate { get; set; }
        public DataTemplate AddNewBookTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is AddNewBookViewModel)
                return AddNewBookTemplate;
            if (item is BookPreviewViewModel)
                return BookPreviewTemplate;
            return base.SelectTemplateCore(item, container);
        }
    }
}
