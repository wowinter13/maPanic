namespace MapPanicApp.UWP.Services.SettingsServices
{
    #region Using

    using System;
    using Windows.UI.Xaml;

    #endregion

    public interface ISettingsService
    {
        bool UseShellBackButton { get; set; }
        ApplicationTheme AppTheme { get; set; }
        TimeSpan CacheMaxDuration { get; set; }
    }
}