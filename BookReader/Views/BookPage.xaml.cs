using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Prism.Windows.Mvvm;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookReader.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public enum BookBageMode
    {
        SinglePage,
        TwoPage,
        Scroll
    }
    public sealed partial class BookPage : SessionStateAwarePage
    {
        public BookBageMode PageMode { get; set; }
        public BookPage()
        {
            this.InitializeComponent();
            DependencyProperty.Register(nameof(PageMode), typeof(BookBageMode), this.GetType(), new PropertyMetadata(BookBageMode.SinglePage));
        }


    }
}
