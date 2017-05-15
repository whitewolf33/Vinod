using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Resume
{
	public class AboutMePageViewModel : BaseViewModel
	{

		List<Timeline> _timelineList;
		public List<Timeline> TimelineList
		{
			get { return _timelineList; }
			set { SetProperty(ref _timelineList, value); }
		}

		public AboutMePageViewModel(INavigationService navigationService) : base(navigationService)
		{
			Task.Run(async () =>
			{
				var dataService = ((App)Application.Current).Container.Resolve<IDataService>();
				if (dataService != null)
					TimelineList = await dataService.GetTimeline();
			});
		}
	}
}
