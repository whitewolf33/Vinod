using System;
using Xamarin.Forms;

namespace Common
{
	public class LineEntry : Entry
	{
		public LineEntry()
		{
			BorderColor = Color.Transparent;
			TextColor = Color.Black;
			PlaceholderColor = Color.Gray;
			FontSize = 14;
		}

		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create("BorderColorProperty", typeof(Color), typeof(LineEntry), Color.Transparent, BindingMode.TwoWay);


		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public static readonly BindableProperty ReturnKeyTextProperty =
			BindableProperty.Create("ReturnKeyTextProperty", typeof(String), typeof(LineEntry), String.Empty);

		public string ReturnKeyText
		{
			get { return (string)GetValue(ReturnKeyTextProperty); }
			set { SetValue(ReturnKeyTextProperty, value); }
		}
	}
}
