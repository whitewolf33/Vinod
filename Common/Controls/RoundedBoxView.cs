using System;
using Xamarin.Forms;

namespace Common
{
	public class RoundedBoxView : BoxView
	{
		/// <summary>
		/// The corner radius property.
		/// </summary>
		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create("CornerRadius", typeof(double), typeof(RoundedBoxView), 0.0);

		/// <summary>
		/// Gets or sets the corner radius.
		/// </summary>
		public double CornerRadius
		{
			get { return (double)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		public RoundedBoxView()
		{

		}
	}
}
