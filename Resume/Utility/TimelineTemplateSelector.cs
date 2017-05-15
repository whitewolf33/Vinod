using System;
using Xamarin.Forms;

namespace Resume
{
	public class TimelineTemplateSelector : DataTemplateSelector
	{
		public DataTemplate OddTemplate { get; set; }

		public DataTemplate EvenTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return ((Timeline)item).Id % 2 == 0 ? EvenTemplate : OddTemplate;
		}
	}
}
