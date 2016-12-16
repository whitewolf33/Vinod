using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;

namespace Resume
{
	public abstract class BaseViewModel : BindableBase, INavigationAware
	{
		public readonly INavigationService NavigationService;

		public DelegateCommand<string> OpenWebsiteCommand { get; private set; }

		public DelegateCommand<string> OpenSocialCommand { get; private set; }

		protected BaseViewModel(INavigationService navigationService)
		{
			NavigationService = navigationService;

			OpenWebsiteCommand = new DelegateCommand<string>((arg) =>
			{
				if (string.IsNullOrWhiteSpace(arg))
					return;
				var browserOptions = new BrowserOptions();
				browserOptions.UseSafariWebViewController = true;
				Color navbarColor =
				((Color)Application.Current.Resources["NavBarBackgroundColor"]);
				browserOptions.ChromeToolbarColor = new ShareColor()
				{
					R = (int)navbarColor.R,
					G = (int)navbarColor.G,
					B = (int)navbarColor.B,
					A = (int)navbarColor.A
				};
				CrossShare.Current.OpenBrowser(arg, browserOptions);
			});

			OpenSocialCommand = new DelegateCommand<string>((arg) =>
			{
				Device.OpenUri(new Uri("fb://page/nodlet"));

			});
		}

		#region INavigationAware Implementation
		public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{

		}
		#endregion
	}
}
