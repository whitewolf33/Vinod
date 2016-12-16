using Xamarin.Forms;

namespace Resume
{
	public partial class WorkExperiencePage : CarouselPage
	{
		public WorkExperiencePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, string.Empty);
		}
	}
}
