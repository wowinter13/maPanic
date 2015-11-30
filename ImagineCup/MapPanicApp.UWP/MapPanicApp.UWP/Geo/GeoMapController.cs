namespace MapPanicApp.UWP.Geo
{
    #region Using

    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.Foundation;
    using MapPanicApp.UWP.Annotations;
    using MapPanicApp.UWP.Geo.HaversineFormula;

    #endregion

    internal class GeoMapController:INotifyPropertyChanged
    {
        private readonly Geolocator mGeolocator = new Geolocator();

        public GeoMapController()
        {
            mGeolocator.PositionChanged += GeolocatorOnPositionChanged;
        }

        private Geopoint mPinPosition;

        public Geopoint PinPosition
        {
            get { return mPinPosition; }
            set
            {
                if (Equals(value, mPinPosition))
                {
                    return;
                }
                mPinPosition = value;
                OnPropertyChanged(nameof(PinPosition));
            }
        }

        private Geoposition mMyPosition;

        public Geoposition MyPosition
        {
            get { return mMyPosition; }
            set
            {
                if (Equals(value, mMyPosition))
                {
                    return;
                }
                mMyPosition = value;
                OnPropertyChanged(nameof(MyPosition));
            }
        }

        public double Distanse
        {
            get
            {
                var distanse = new Haversine().Distance(MyPosition.Coordinate.Point, PinPosition,
                    DistanceType.Kilometers);
                return distanse;
            }
        }

        private void GeolocatorOnPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            MyPosition = args.Position;

        }

        public async Task<Geoposition> CurrentPosition()
        {
            var point = await new Geolocator().GetGeopositionAsync();
            return point;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    namespace HaversineFormula
    {
        /// <summary>
        ///     The distance type to return the results in.
        /// </summary>
        public enum DistanceType
        {
            Miles,
            Kilometers
        };

        /// <summary>
        ///     Specifies a Latitude / Longitude point.
        /// </summary>
        public struct Position
        {
            public double Latitude;
            public double Longitude;
        }

        internal class Haversine
        {
            /// <summary>
            ///     Returns the distance in miles or kilometers of any two
            ///     latitude / longitude points.
            /// </summary>
            public double Distance(Geopoint pos1, Geopoint pos2, DistanceType type)
            {
                double R = (type == DistanceType.Miles) ? 3960 : 6371;
                var dLat = toRadian(pos2.Position.Latitude - pos1.Position.Latitude);
                var dLon = toRadian(pos2.Position.Longitude - pos1.Position.Longitude);
                var a = Math.Sin(dLat/2)*Math.Sin(dLat/2) +
                        Math.Cos(toRadian(pos1.Position.Latitude))*Math.Cos(toRadian(pos2.Position.Latitude))*
                        Math.Sin(dLon/2)*Math.Sin(dLon/2);
                var c = 2*Math.Asin(Math.Min(1, Math.Sqrt(a)));
                var d = R*c;
                return d;
            }

            /// <summary>
            ///     Convert to Radians.
            /// </summary>
            private double toRadian(double val)
            {
                return (Math.PI/180)*val;
            }
        }
    }
}