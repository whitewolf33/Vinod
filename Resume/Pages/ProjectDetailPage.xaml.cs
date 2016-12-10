using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Resume
{
	public partial class ProjectDetailPage : ContentPage
	{
		public ProjectDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, String.Empty);
		}
	}
}
