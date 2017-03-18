using System;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using Resume.Helpers;
using System.Threading.Tasks;

namespace Resume
{
	public class LoginPageViewModel : BaseViewModel
	{

		public DelegateCommand AuthenticateCommand { get; private set; }

		public DelegateCommand RequestAccessCommand { get; private set; }

		public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			AuthenticateCommand = new DelegateCommand(() =>
			{
				NavigationService.NavigateAsync("http://resume.vinod.com.au/NavigationPageEx/WorkExperiencePage");
			});

			RequestAccessCommand = new DelegateCommand(() => Application.Current.MainPage = RootPage.Instance);

			Task.Run(async () =>
			{
				if (Settings.UseTouchID)
				{
					var success = await Acr.Biometrics.Biometrics.Instance.Evaluate("Use TouchID To Login");
					if (success)
					{
						Device.BeginInvokeOnMainThread(async () => await NavigationService.NavigateAsync("http://resume.vinod.com.au/RootPage/NavigationPageEx/AboutMePage"));
					}
				}
			});
		}
	}
}
