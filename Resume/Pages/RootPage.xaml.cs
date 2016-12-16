using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Resume
{
	public partial class RootPage : MasterDetailPage
	{

		private static RootPage instance = null;

		public static RootPage Instance
		{
			get
			{
				if (instance == null)
					instance = new RootPage();

				return instance;
			}
			set
			{
				instance = value;
			}
		}

		public MenuPage Menu { get; private set; }

		public RootPage()
		{
			InitializeComponent();

			masterPage.ListView.ItemSelected += OnMenuItemSelected;
		}

		void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MenuItem;
			if (item != null)
			{
				Page detailPage = (Page)Activator.CreateInstance(item.Target);

				NavigationPage navPage = new NavigationPage(detailPage)
				{
					BarBackgroundColor = (Color)Application.Current.Resources["NavBarBackgroundColor"],
					BarTextColor = (Color)Application.Current.Resources["NavBarTextColor"]
				};

				Detail = navPage;

				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}
