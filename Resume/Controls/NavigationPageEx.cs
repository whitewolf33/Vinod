using System;
using Xamarin.Forms;

namespace Resume
{
	public class NavigationPageEx : NavigationPage
	{
		public NavigationPageEx(Page rootPage) : base(rootPage)
		{
			BarBackgroundColor = (Color)Application.Current.Resources["NavBarBackgroundColor"];
			BarTextColor = (Color)Application.Current.Resources["NavBarTextColor"];
		}
	}
}
