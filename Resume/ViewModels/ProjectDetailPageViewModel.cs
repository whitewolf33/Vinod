using System;
using Prism.Navigation;

namespace Resume
{
	public class ProjectDetailPageViewModel : BaseViewModel
	{
		Project project;

		public Project Project
		{
			get
			{
				return project;
			}

			set
			{
				project = value;
				OnPropertyChanged("Project");
			}
		}

		public ProjectDetailPageViewModel(INavigationService navigationService) : base(navigationService)
		{
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			if (parameters != null && parameters.ContainsKey("Project"))
			{

				Project = parameters["Project"] as Project;
			}
		}
	}
}
