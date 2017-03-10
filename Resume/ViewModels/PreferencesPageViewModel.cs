using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Resume
{
	public class PreferencesPageViewModel : BaseViewModel
	{


		List<Preference> _preferences;
		public List<Preference> Preferences
		{
			get { return _preferences; }
			set { 
				SetProperty(ref _preferences, value);
				ListViewHeight = value.Count * _listViewRowHeigt;
			}
		}

		double _listViewRowHeigt = 95;
		double _listViewHeight;

		public double ListViewHeight
		{
			get
			{
				return _listViewHeight;
			}

			set
			{
				_listViewHeight = value;
			}
		}

		public PreferencesPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			Task.Run(async () =>
			{
				var dataService = ((App)Application.Current).Container.Resolve<IDataService>();
				if (dataService != null)
					Preferences = await dataService.GetPreferences();
			});
		}
	}
}
