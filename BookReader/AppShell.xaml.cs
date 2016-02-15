using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BookReader
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AppShell : Page
    {        
        public AppShell()
        {
            this.InitializeComponent();
        }

        internal void SetContentFrame(Frame frame)
        {
            HamburgerSplitView.Content = frame;
        }

        internal void SetMenuPaneContent(UIElement content)
        {
            HamburgerSplitView.Pane = content;
        }
    }
}
