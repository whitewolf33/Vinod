using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Resume
{
	public class CompanyMap : Map
	{
		public Location CompanyLocation
		{
			get { return (Location)GetValue(CompanyLocationProperty); }
			set { SetValue(CompanyLocationProperty, value); }
		}

		public static readonly BindableProperty CompanyLocationProperty =
			BindableProperty.Create("CompanyLocation", typeof(Location), typeof(CompanyMap), null, BindingMode.TwoWay, null,
									(bindable, oldValue, newValue) =>
									{
										if (newValue != null)
										{
											var newLocation = (Location)newValue;
											var position = new Position(newLocation.Latitude, newLocation.Longitude);
											((CompanyMap)bindable).Pins.Add(new Pin { Label = newLocation.Name, Position = position });

											((CompanyMap)bindable).MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
										}
									});

	}
}
