using Xamarin.Forms;

namespace Common
{
	public class ListViewExt : ListView
	{
		public ListViewExt()
		{
			// This is to ensure that the selection does not remain on the screen
			this.ItemTapped += (sender, e) =>
			{
				if (e.Item != null)
				{
					((ListView)sender).SelectedItem = null;
				}
			};
		}
	}
}
