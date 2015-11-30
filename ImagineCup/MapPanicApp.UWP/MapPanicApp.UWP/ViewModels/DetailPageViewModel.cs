namespace MapPanicApp.UWP.ViewModels
{
    #region Using

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml.Navigation;
    using Sample.Mvvm;
    using Template10.Services.NavigationService;

    #endregion

    public class DetailPageViewModel : ViewModelBase
    {
        private string _Value = "Default";

        public DetailPageViewModel()
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
            else
            {
                // use navigation parameter
                Value = parameter?.ToString();
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
            args.Cancel = false;
        }
    }
}