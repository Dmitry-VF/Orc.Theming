﻿namespace Orc.Theming.Example
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;
    using Catel.IoC;
    using Catel.Logging;
    using Catel.Services;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        #endregion

        #region Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            var languageService = ServiceLocator.Default.ResolveType<ILanguageService>();

            // Note: it's best to use .CurrentUICulture in actual apps since it will use the preferred language
            // of the user. But in order to demo multilingual features for devs (who mostly have en-US as .CurrentUICulture),
            // we use .CurrentCulture for the sake of the demo
            languageService.PreferredCulture = CultureInfo.CurrentCulture;
            languageService.FallbackCulture = new CultureInfo("en-US");

            FontImage.RegisterFont("FontAwesome", new FontFamily(new Uri("pack://application:,,,/Orc.Theming.Example;component/Resources/Fonts/", UriKind.RelativeOrAbsolute), "./#FontAwesome"));
            FontImage.DefaultFontFamily = "FontAwesome";

            // This shows the StyleHelper, but uses a *copy* of the Orchestra themes. The default margins for controls are not defined in
            // Orc.Theming since it's a low-level library. The final default styles should be in the shell (thus Orchestra makes sense)
            StyleHelper.CreateStyleForwardersForDefaultStyles();

            Log.Info("Starting application");
            Log.Info("This log message should show up as debug");

            base.OnStartup(e);
        }
        #endregion
    }
}
