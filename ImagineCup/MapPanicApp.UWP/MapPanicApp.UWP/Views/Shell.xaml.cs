namespace Sample.Views
{
    #region Using

    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Template10.Common;
    using Template10.Services.NavigationService;

    #endregion

    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SplitView
    public sealed partial class Shell : Page
    {
        public Shell(NavigationService navigationService)
        {
            Instance = this;
            InitializeComponent();
            MyHamburgerMenu.NavigationService = navigationService;
            VisualStateManager.GoToState(Instance, Instance.NormalVisualState.Name, true);
        }

        public static Shell Instance { get; set; }

        public static void SetBusyVisibility(Visibility visible, string text = null)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                switch (visible)
                {
                    case Visibility.Visible:
                        Instance.FindName(nameof(BusyScreen));
                        Instance.BusyText.Text = text ?? string.Empty;
                        if (VisualStateManager.GoToState(Instance, Instance.BusyVisualState.Name, true))
                        {
                            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                                AppViewBackButtonVisibility.Collapsed;
                        }
                        break;
                    case Visibility.Collapsed:
                        if (VisualStateManager.GoToState(Instance, Instance.NormalVisualState.Name, true))
                        {
                            BootStrapper.Current.UpdateShellBackButton();
                        }
                        break;
                }
            });
        }

        private void MyHamburgerMenu_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}