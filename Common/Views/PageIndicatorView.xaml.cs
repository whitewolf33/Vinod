using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Common
{
	public partial class PageIndicatorView : ContentView, IPage
	{
		//public static readonly BindableProperty CurrentIndicatorProperty =
		//	BindableProperty.Create("CurrentIndicator", typeof(int), typeof(PageIndicatorView), 0);

		//public int CurrentIndicator
		//{
		//	get { return (int)GetValue(CurrentIndicatorProperty); }
		//	set { SetValue(CurrentIndicatorProperty, value); }
		//}


		public static readonly BindableProperty IndexProperty =
			BindableProperty.Create("Index", typeof(int), typeof(PageIndicatorView), 0);

		public int Index
		{
			get { return (int)GetValue(IndexProperty); }
			set { SetValue(IndexProperty, value); }
		}

		public static readonly BindableProperty PagesProperty =
			BindableProperty.Create("Pages", typeof(List<IPage>), typeof(PageIndicatorView), null);

		public List<IPage> Pages
		{
			get { return (List<IPage>)GetValue(PagesProperty); }
			set { SetValue(PagesProperty, value); }
		}
		int totalPages;

		public int TotalPages
		{
			get
			{
				return totalPages;
			}

			set
			{
				totalPages = value;
				OnPropertyChanged("TotalPages");
			}
		}

		public PageIndicatorView()
		{
			try
			{
				InitializeComponent();
			}
			catch (Exception ex)
			{

			}
		}
	}
}
