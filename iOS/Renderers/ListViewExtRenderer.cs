using System.ComponentModel;
using Resume.iOS;
using Common;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Resume;

[assembly: ExportRenderer(typeof(ListViewEx), typeof(ListViewExtRenderer))]
namespace Resume.iOS
{
	public class ListViewExtRenderer : ListViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			if (Control != null && Element != null)
			{
				Control.Bounces = false;
				//Control.ScrollEnabled = false;
				Control.ClipsToBounds = false;
			}
		}
	}
}