using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapPanicApp.UWP
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Maps;

    class Settings
    {
     public  static MapStyle MapStyle { get; set; }=MapStyle.Terrain;

    }
}
