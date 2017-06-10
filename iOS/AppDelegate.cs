using System;
using Common;
using Foundation;
using UIKit;
using WebKit;
using Xam.Plugin.iOS;

namespace Resume.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			FormsWebViewRenderer.Init();
			FormsWebViewRenderer.OnControlChanging += (sender, element, control) =>
		   {
				var webView = control as WKWebView;
		   };

			global::Xamarin.Forms.Forms.Init();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif
			var buildVersion = GetAppBuildVersion();
			LoadApplication(new App());
			AppConfig.APP_VERSION = buildVersion;
			AppConfig.SCREEN_WIDTH = (int)UIScreen.MainScreen.Bounds.Width;
			AppConfig.SCREEN_HEIGHT = (int)UIScreen.MainScreen.Bounds.Height;
			Xamarin.FormsMaps.Init();
			return base.FinishedLaunching(app, options);
		}


		private string GetAppBuildVersion()
		{
			try
			{
				return NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
			}
			catch (Exception ex)
			{
				MyInsights.Report(ex);
				return string.Empty;
			}
		}
	}
}
