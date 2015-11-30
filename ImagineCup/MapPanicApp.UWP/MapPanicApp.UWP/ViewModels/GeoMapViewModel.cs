namespace MapPanicApp.UWP.ViewModels
{
    #region Using

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml.Navigation;
    using Sample.Mvvm;
    using Sample.Views;
    using Template10.Services.NavigationService;

    #endregion

    public class GeoMapViewModel : ViewModelBase
    {
        private string _Value = string.Empty;

        public GeoMapViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                // designtime data
                Value = "Designtime value";
            }
        }

        public string Value
        {
            get { return _Value; }
            set { Set(ref _Value, value); }
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(Value)))
                {
                    Value = state[nameof(Value)]?.ToString();
                }
                // clear any cache
                state.Clear();
            }
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(Value)] = Value;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            base.OnNavigatingFrom(args);
        }

        public void GotoDetailsPage()
        {
            NavigationService.Navigate(typeof (DetailPage), Value);
        }
    }
}