using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Resume
{
	public class ProjectsPageViewModel : BaseViewModel
	{
		List<Project> _projectsList;
		public List<Project> ProjectsList
		{
			get { return _projectsList; }
			set { SetProperty(ref _projectsList,  value); }
		}	

		public ProjectsPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			Task.Run(async () =>
			{
				var dataService = ((App)Application.Current).Container.Resolve<IDataService>();
				if (dataService != null)
					ProjectsList = await dataService.GetProjectsList();
			});
		}
	}
}

