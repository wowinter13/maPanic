﻿#pragma checksum "V:\HAKATON\MapPanic\MapPanicApp.UWP\MapPanicApp.UWP\Views\GeoMapView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A94C6345187E91BB709DAB2A7F62D212"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MapPanicApp.UWP.Views
{
    partial class GeoMapView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.RootGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.myMap = (global::Windows.UI.Xaml.Controls.Maps.MapControl)(target);
                    #line 49 "..\..\..\Views\GeoMapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.myMap).MapTapped += this.myMap_MapTapped_1;
                    #line default
                }
                break;
            case 3:
                {
                    this.ErrorBorder = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 4:
                {
                    this.StatusBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.zoomSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 6:
                {
                    this.headingSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 7:
                {
                    this.desiredPitchSlider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 8:
                {
                    this.StyleStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 9:
                {
                    this.trafficFlowVisibleCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    #line 31 "..\..\..\Views\GeoMapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.trafficFlowVisibleCheckBox).Checked += this.TrafficFlowVisible_Checked;
                    #line 32 "..\..\..\Views\GeoMapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.CheckBox)this.trafficFlowVisibleCheckBox).Unchecked += this.trafficFlowVisibleCheckBox_Unchecked;
                    #line default
                }
                break;
            case 10:
                {
                    this.styleCombobox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 33 "..\..\..\Views\GeoMapView.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.styleCombobox).SelectionChanged += this.styleCombobox_SelectionChanged;
                    #line default
                }
                break;
            case 11:
                {
                    this.description = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

