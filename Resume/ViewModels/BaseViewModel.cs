using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;
using Prism.Services;

namespace Resume
{
	public abstract class BaseViewModel : BindableBase, INavigationAware
	{
		public readonly INavigationService NavigationService;

		public DelegateCommand<string> OpenWebsiteCommand { get; private set; }

		public DelegateCommand<string> OpenSocialCommand { get; private set; }

		public DelegateCommand<string> CallCommand { get; private set; }

		public DelegateCommand<Location> DirectionTappedCommand { get; private set; }

		protected IPageDialogService PageDialogService { get; private set; }

		protected BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : this(navigationService)
		{
			PageDialogService = pageDialogService;
		}

		protected BaseViewModel(INavigationService navigationService)
		{
			NavigationService = navigationService;

			DirectionTappedCommand = new DelegateCommand<Location>((location) =>
			{
				var name = location.Name.Replace("&", "and"); // var name = Uri.EscapeUriString(place.Name);
				var loc = string.Format("{0},{1}", location.Latitude, location.Longitude);
				var request = Device.OnPlatform(
				  // iOS doesn't like %s or spaces in their URLs, so manually replace spaces with +s
				  string.Format("http://maps.apple.com/maps?q={0}&sll={1}", name.Replace(' ', '+'), loc),
				  string.Format("geo:0,0?q={0}({1})", loc, name),
				  // WinPhone
				  string.Format("bingmaps:?cp={0}&q={1}", loc, name)
				);

				Device.OpenUri(new Uri(request));

			});

			CallCommand = new DelegateCommand<string>(async (arg) =>
			{
				if (string.IsNullOrWhiteSpace(arg))
					return;
				if (PageDialogService != null)
				{
					var confirm = await PageDialogService.DisplayAlertAsync("Confirm", String.Format("Call {0}?", arg.Trim()), "OK", "Cancel");
					if (confirm)
						Device.OpenUri(new Uri("tel:" + arg.Trim().Replace(" ", "")));
				}
				else
				{
					throw new Exception("Call the constructor with dependency injection");
				}
			});

			OpenWebsiteCommand = new DelegateCommand<string>((arg) =>
			{
				if (string.IsNullOrWhiteSpace(arg))
					return;
				var browserOptions = new BrowserOptions();
				browserOptions.UseSafariWebViewController = true;
				Color navbarColor =
				((Color)Application.Current.Resources["NavBarBackgroundColor"]);
				var shareColor = new ShareColor()
				{
					R = (int)navbarColor.R,
					G = (int)navbarColor.G,
					B = (int)navbarColor.B,
					A = (int)navbarColor.A
				};
				browserOptions.ChromeToolbarColor = shareColor;
				browserOptions.SafariBarTintColor= shareColor;
				CrossShare.Current.OpenBrowser(arg, browserOptions);
			});

			OpenSocialCommand = new DelegateCommand<string>((arg) =>
			{
				switch (arg.ToLower())
				{
					case "facebook":
						{
							Device.OpenUri(new Uri("fb://profile/609722353"));
							break;
						}
					case "twitter":
						{
							Device.OpenUri(new Uri("twitter://user?id=vsrinivasan33"));
							break;
						}

					case "linkedin":
						{
							Device.OpenUri(new Uri("linkedin://profile/vsrinivasan33"));
							break;
						}
					case "github":
						{
							OpenWebsiteCommand.Execute("https://github.com/whitewolf33");
							break;
						}
					case "email":
						{
							Device.OpenUri(new Uri("mailto:itsmevinod@yahoo.com"));
						}
						break;
				}

			});

		}

		#region INavigationAware Implementation
		public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{

		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{

		}
		#endregion
	}
}
