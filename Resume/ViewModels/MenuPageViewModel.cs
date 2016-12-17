using System.Collections.Generic;
using Prism.Navigation;

namespace Resume
{
	public class MenuPageViewModel : BaseViewModel
	{
		List<MenuItem> menuItems;

		public List<MenuItem> MenuItems
		{
			get
			{
				return menuItems;
			}

			set
			{
				menuItems = value;
				OnPropertyChanged("MenuItems");
			}
		}

		public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			var masterPageItems = new List<MenuItem>();
			masterPageItems.Add(new MenuItem
			{
				Title = "About Me",
				Icon = "aboutme.png",
				Target = typeof(AboutMePage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "Qualifications",
				Icon = "degree.png",
				Target = typeof(QualificationsPage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "Work Experience",
				Icon = "work.png",
				Target = typeof(WorkExperiencePage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "Projects",
				Icon = "projects.png",
				Target = typeof(ProjectDetailPage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "Technical Skills",
				Icon = "skills.png",
				Target = typeof(TechnicalSkillsPage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "Settings",
				Icon = "settings.png",
				Target = typeof(ProjectDetailPage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "About this App",
				Icon = "aboutapp.png",
				Target = typeof(ProjectDetailPage)
			});

			MenuItems = masterPageItems;
		}
	}
}
