﻿namespace Orc.Theming
{
    using System.Reflection;
    using System.Windows;

    public static class ScreenHelper
    {
        private static Size DpiCache;

        public static Size GetDpi()
        {
            if (DpiCache.Width != 0d && DpiCache.Height != 0d)
            {
                return DpiCache;
            }

            var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
            var dpiYProperty = typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);

            DpiCache.Width = (int)dpiXProperty.GetValue(null, null);
            DpiCache.Height = (int)dpiYProperty.GetValue(null, null);

            return DpiCache;
        }
    }
}
