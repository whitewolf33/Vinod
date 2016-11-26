using System;
using Xamarin.Forms;

namespace Common
{
	public class PageIndicatorToColorConverter : IValueConverter
	{
		public Color SuccessColor { get; set; } = Color.Green;
		public Color FailureColor { get; set; } = Color.Transparent;

		public int PageIndex
		{
			get; set;
		}


		#region IValueConverter implementation

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int currentIndicator;
			int boxViewIndex = 0;

			if (parameter != null && parameter is Binding)
			{
				var source = ((Binding)parameter).Source;
				if (source != null && source is IPage)
				{
					boxViewIndex = ((IPage)source).Index;
				}
			}

			Int32.TryParse(value.ToString(), out currentIndicator);
			//Int32.TryParse(parameter.ToString(), out boxViewIndex);

			if (currentIndicator > 0 && boxViewIndex > 0)
			{
				if (currentIndicator <= boxViewIndex)
					return SuccessColor;
			}
			return FailureColor;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
