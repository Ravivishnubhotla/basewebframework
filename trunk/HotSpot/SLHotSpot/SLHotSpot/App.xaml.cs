using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLHotSpot
{
    public partial class App : Application
    {
 
        public static SLHotSpotSetting setting = new SLHotSpotSetting();

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;



            InitializeComponent();
 

            if (!System.Windows.Controls.Theming.WhistlerBlueTheme.GetIsApplicationTheme(Application.Current))
                System.Windows.Controls.Theming.WhistlerBlueTheme.SetIsApplicationTheme(Application.Current, true);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Dictionary<string, string> dir = e.InitParams as Dictionary<string, string>;

            setting.HotSpotBgImage = GetSettingValue(dir, "HotSpotBgImage");

            setting.DataID = GetSettingValue(dir, "DataID");

            setting.ControlMode = (Mode)Enum.Parse(typeof(Mode), GetSettingValue(dir, "Mode"), true);

            setting.WebServiceUrl = GetSettingValue(dir, "WebServiceUrl");

            setting.RootUrl = GetSettingValue(dir, "RootUrl");


            this.RootVisual = new MainPage(setting);
        }

 

        private static string GetSettingValue(Dictionary<string, string> dir,string key)
        {
            if (dir != null && dir.ContainsKey(key) && !string.IsNullOrEmpty(dir[key]))
                return dir[key];

            return string.Empty;
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
