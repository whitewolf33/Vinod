using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Common;

namespace Resume
{
	public class PreferencesPageViewModel : BaseViewModel
	{


		ObservableCollectionExt<Preference> _preferences;
		public ObservableCollectionExt<Preference> Preferences
		{
			get { return _preferences; }
			set
			{
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

		Preference _selectedPreference;
		public Preference SelectedPreference
		{
			get { return _selectedPreference; }
			set { 
				SetProperty(ref _selectedPreference, value);
				if (value != null)
					PreferenceActionCommand.Execute(value);
			}
		}

		public DelegateCommand<Preference> PreferenceActionCommand { get; private set; }

		public PreferencesPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			PreferenceActionCommand = new DelegateCommand<Preference>((preference) =>
			{
				if (preference.PreferenceAction != null)
				{
					preference.PreferenceAction.Invoke(preference);
					RaisePropertyChanged("Icon");
				}
			});

			Task.Run(async () =>
			{
				var dataService = ((App)Application.Current).Container.Resolve<IDataService>();
				if (dataService != null)
					Preferences = new ObservableCollectionExt<Preference>(await dataService.GetPreferences());
			});
		}
	}
}
