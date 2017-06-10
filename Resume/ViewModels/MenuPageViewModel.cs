using System.Collections.Generic;
using Prism.Navigation;
using Prism.Services;

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

		Location _myLocation = new Location { Name = "Melbourne, Australia", Latitude = -37.822671d, Longitude = 144.9456918d };

		public Location MyLocation
		{
			get
			{
				return _myLocation;
			}

			set
			{
				SetProperty(ref _myLocation, value);
			}
		}

		public MenuPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
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
				Target = typeof(ProjectsPage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "Technical Skills",
				Icon = "skills.png",
				Target = typeof(TechnicalSkillsPage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "Preferences",
				Icon = "settings.png",
				Target = typeof(PreferencesPage)
			});
			masterPageItems.Add(new MenuItem
			{
				Title = "About this App",
				Icon = "aboutapp.png",
				Target = typeof(WebViewPage)
			});

			MenuItems = masterPageItems;

		}
	}
}
