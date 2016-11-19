using System;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Resume
{
	public abstract class BaseViewModel : BindableBase, INavigationAware
	{
		public readonly INavigationService NavigationService;

		protected BaseViewModel(INavigationService navigationService)
		{
			NavigationService = navigationService;
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
