namespace Sample.Views
{
    #region Using

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using MapPanicApp.UWP.ViewModels;

    #endregion

    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public SettingsPageViewModel ViewModel => DataContext as SettingsPageViewModel;
    }
}