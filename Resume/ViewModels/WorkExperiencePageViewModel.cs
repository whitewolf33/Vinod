using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using System.Linq;
using Common;

namespace Resume
{
	public class WorkExperiencePageViewModel : BaseViewModel
	{
		List<WorkExperience> workExperieneList;

		public List<WorkExperience> WorkExperieneList
		{
			get
			{
				return workExperieneList;
			}

			set
			{
				workExperieneList = value;
				OnPropertyChanged("Pages");
				OnPropertyChanged("WorkExperieneList");
			}
		}

		public List<IPage> Pages
		{
			get
			{
				return WorkExperieneList.Cast<IPage>().ToList();
			}
		}

		public int PageIndicatorHeight
		{
			get
			{
				return workExperieneList != null ? workExperieneList.Count * 20 : 20;
			}
		}

		public WorkExperiencePageViewModel(INavigationService navigationService) : base(navigationService)
		{
			Task.Run(async () =>
			{
				var dataService = ((App)Application.Current).Container.Resolve<IDataService>();
				if (dataService != null)
					WorkExperieneList = await dataService.GetWorkExperiences();
			});
		}
	}
}
