 // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MapPanicApp.UWP.Views
{
    #region Using

    using System.Diagnostics;
    using Windows.Devices.Geolocation;
    using Windows.Foundation;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Maps;
    using Windows.UI.Xaml.Navigation;

    #endregion

    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GeoMapView : Page
    {
        private RandomAccessStreamReference mapIconStreamReference;

        public GeoMapView()
        {
            InitializeComponent();
            myMap.Loaded += MyMap_Loaded;
            myMap.MapTapped += MyMap_MapTapped;
        }

        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            myMap.Center =
                new Geopoint(new BasicGeoposition
                {
                    //Geopoint for Seattle 
                    Latitude = 47.604,
                    Longitude = -122.329
                });
            myMap.ZoomLevel = 12;
        }

        private void MyMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            var tappedGeoPosition = args.Location.Position;
            var status = "MapTapped at \nLatitude:" + tappedGeoPosition.Latitude + "\nLongitude: " +
                         tappedGeoPosition.Longitude;
            //rootPage.NotifyUser(status, NotifyType.StatusMessage);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //rootPage = MainPage.Current;
        }

        private void TrafficFlowVisible_Checked(object sender, RoutedEventArgs e)
        {
            myMap.TrafficFlowVisible = true;
        }

        private void trafficFlowVisibleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            myMap.TrafficFlowVisible = false;
        }

        private void styleCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (styleCombobox.SelectedIndex)
            {
                case 0:
                    myMap.Style = MapStyle.None;
                    break;
                case 1:
                    myMap.Style = MapStyle.Road;
                    break;
                case 2:
                    myMap.Style = MapStyle.Aerial;
                    break;
                case 3:
                    myMap.Style = MapStyle.AerialWithRoads;
                    break;
                case 4:
                    myMap.Style = MapStyle.Terrain;
                    break;
            }
        }

        private void myMap_MapTapped_1(MapControl sender, MapInputEventArgs args)
        {
            Debug.WriteLine(args.Location);
            var mapIcon1 = new MapIcon();
            mapIcon1.Location = args.Location;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = "My Friend";
            mapIcon1.Image = mapIconStreamReference;
            mapIcon1.ZIndex = 0;
            myMap.MapElements.Clear();
            myMap.MapElements.Add(mapIcon1);
        }
    }
}