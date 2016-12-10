using System;
using Xamarin.Forms;

namespace Resume
{
	public class ListViewEx : ListView
	{
		public ListViewEx()
		{
			this.ItemSelected += (sender, e) =>
			{
				if (this.SelectedItem != null)
					SelectedItem = null;
			};
		}
	}
}
