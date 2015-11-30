namespace MapPanicApp.UWP
{
    #region Using

    using System.Threading.Tasks;
    using Windows.ApplicationModel.Activation;
    using Windows.Services.Maps;
    using Windows.UI.Xaml;
    using MapPanicApp.UWP.Services.SettingsServices;
    using Sample.Views;
    using Template10.Common;

    #endregion

    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki
    sealed partial class App : BootStrapper
    {
        private readonly ISettingsService settings;

        public App()
        {
            InitializeComponent();
            SplashFactory = e => new Splash(e);

            settings = SettingsService.Instance;
            RequestedTheme = settings.AppTheme;
            CacheMaxDuration = settings.CacheMaxDuration;
            ShowShellBackButton = settings.UseShellBackButton;
            MapService.ServiceToken =
              "S6FFHXrk4arqUSdOdkfh~rnZWaCecCayKbtUr7ekTeg~AkLV6Bch4-QSERc_qnRphY7Pbzsosf9pRCSvf8EGQ2izDLspp5iWSCAs9-Sc8Qf2";

        }

        // runs even if restored from state
        public override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // setup hamburger shell
            var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
            Window.Current.Content = new Shell(nav);
            return Task.FromResult<object>(null);
        }

        // runs only when not restored from state
        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            await Task.Delay(50);
            NavigationService.Navigate(typeof (MainPage));
        }
    }
}