using System;
using Prism.Commands;
using Prism.Navigation;

namespace Resume
{
	public class LoginPageViewModel : BaseViewModel
	{

		public DelegateCommand AuthenticateCommand { get; private set; }

		public DelegateCommand RequestAccessCommand { get; private set; }

		public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			AuthenticateCommand = new DelegateCommand(() => { });

			RequestAccessCommand = new DelegateCommand(() => App.Current.MainPage = RootPage.Instance);
		}
	}
}
