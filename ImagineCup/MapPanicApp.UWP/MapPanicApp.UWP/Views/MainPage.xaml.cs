namespace Sample.Views
{
    #region Using

    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using Windows.ApplicationModel.Core;
    using Windows.Data.Xml.Dom;
    using Windows.Foundation;
    using Windows.Storage.Streams;
    using Windows.UI.Core;
    using Windows.UI.Notifications;
    using Windows.UI.Popups;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Maps;
    using Windows.UI.Xaml.Navigation;
    using MapPanicApp.UWP;
    using MapPanicApp.UWP.Geo;
    using MapPanicApp.UWP.ViewModels;

    #endregion

    public sealed partial class MainPage : Page
    {
        private readonly GeoMapController Controller = new GeoMapController();
        private readonly MapIcon mapIcon1;
        private readonly RandomAccessStreamReference mapIconStreamReference;
        private readonly RandomAccessStreamReference meIconStreamReference;
        private readonly MapIcon myIcon1;
        private bool messageShown;
        private bool pinOnMap;

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPin.png"));
            meIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Me.png"));
            mapIcon1 = new MapIcon
            {
                NormalizedAnchorPoint = new Point(0.5, 0.5),
                Title = "",
                Image = mapIconStreamReference,
                ZIndex = 0
            };
            myIcon1 = new MapIcon
            {
                Location = myMap.Center,
                NormalizedAnchorPoint = new Point(0.5, 0.5),
                Title = "",
                Image = meIconStreamReference,
                ZIndex = 0
            };


        }

        // strongly-typed view models enable x:bind
        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        private void myMap_MapTapped_1(MapControl sender, MapInputEventArgs args)
        {
            Debug.WriteLine(args.Location);
            messageShown = false;
            pinOnMap = true;
            Controller.PinPosition = args.Location;
        }

        private async void UpdateMyMap()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {

                    //DateTime scheduledTime = DateTime.Now.AddMinutes(1);
                    //TimeSpan snoozeInterval = TimeSpan.FromMinutes(5);
                    //var scheduledToast = new ScheduledToastNotification(new XmlDocument(), scheduledTime, snoozeInterval, 0);
                    //toastNotifier

                //var toast = new ToastNotification(doc);
                //var scheduledToast = new ScheduledToastNotification("liblatadah", DateTime.Now.AddMinutes(5));
                //toastNotifier.AddToSchedule(scheduledToast);


    


                    if (pinOnMap)
                    {
                        try
                        {
                            if (pinOnMap)
                            {
                                myMap.Center = Controller.MyPosition.Coordinate.Point;
                            }
                            mapIcon1.Location = Controller.PinPosition;
                            myMap.MapElements.Remove(mapIcon1);
                            myMap.MapElements.Add(mapIcon1);
                            var dist = Controller.Distanse;
                            if (dist < 0.2)
                            {
                                messageShown = true;
                                await new MessageDialog("Вы достигли зоны").ShowAsync();

                                Random random = new Random((int)DateTime.Now.Ticks);

                                const string TOAST = @"
<toast>
  <visual>
    <binding template=""ToastGeneric"">
      <text>Sample</text>
      <text>This is a simple toast notification example</text>
      <image placement = ""AppLogoOverride"" src=""Gibrid.png"" />
    </binding>
  </visual>
  <actions>
    <action content = ""check"" arguments=""check"" imageUri=""Gibrid.png"" />
    <action content = ""cancel"" arguments=""cancel""/>
  </actions>
  <audio src =""ms-winsoundevent:Notification.Reminder""/>
</toast>";




                                var when = DateTime.Now.AddSeconds(0.1);

                                var offset = new DateTimeOffset(when);

                                Windows.Data.Xml.Dom.XmlDocument xml = new Windows.Data.Xml.Dom.XmlDocument();

                                xml.LoadXml(TOAST);

                                ScheduledToastNotification toast = new ScheduledToastNotification(xml, offset)
                                {
                                    Id = random.Next(1, 100000000).ToString()
                                };


                                ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
                                var v = ToastNotificationManager.CreateToastNotifier().GetScheduledToastNotifications().ToArray();
                                //alert   
                            }
                        }
                        catch (Exception exc)
                        {
                        }
                    }

                    if (Controller.MyPosition != null)
                    {
                        try
                        {
                            if (!pinOnMap)
                            {
                                myMap.Center = Controller.MyPosition.Coordinate.Point;
                            }
                            myIcon1.Location = Controller.MyPosition.Coordinate.Point;
                            myMap.MapElements.Remove(myIcon1);
                            myMap.MapElements.Add(myIcon1);
                            myMap.UpdateLayout();
                        }

                        catch (Exception exc)
                        {
                        }
                    }
                    myMap.Style = Settings.MapStyle;
                });
        }

        private void myMap_MapHolding(MapControl sender, MapInputEventArgs args)
        {
            Debug.WriteLine("!" + args.Location);
        }

        #region Overrides of Page

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Controller.PropertyChanged += Controller_PropertyChanged;
            UpdateMyMap();
        }

        #region Overrides of Page

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Controller.PropertyChanged -= Controller_PropertyChanged;
        }

        #endregion

        private void Controller_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateMyMap();
        }

        #endregion
    }
}