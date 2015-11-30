namespace Sample.Views
{
    #region Using

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using MapPanicApp.UWP.ViewModels;

    #endregion

    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public DetailPageViewModel ViewModel => DataContext as DetailPageViewModel;
    }
}