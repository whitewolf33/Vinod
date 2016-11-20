using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

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
				OnPropertyChanged("WorkExperieneList");
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
