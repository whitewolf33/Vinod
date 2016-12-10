using System;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

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

			RequestAccessCommand = new DelegateCommand(() => NavigationService.NavigateAsync("WorkExperiencePage"));
		}
	}
}
