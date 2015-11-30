using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapPanicApp.UWP
{
    using System.Runtime.CompilerServices;
    using Windows.Devices.Geolocation;
    using Windows.Foundation;

    class GeoPositionManager
    {
        public static async Task<Geoposition> GetPoint()
        {
            var point =await new Geolocator().GetGeopositionAsync();
            return point;
        }
       
    }
}
