using Prism.Navigation;

namespace Resume
{
	public class QualificationsPageViewModel : BaseViewModel
	{
		QualificationsViewViewModel qualifications;
		public QualificationsViewViewModel Qualifications
		{
			get
			{
				return qualifications;
			}

			set
			{
				qualifications = value;
				OnPropertyChanged("Qualifications");
			}
		}

		public QualificationsPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			Qualifications = new QualificationsViewViewModel(navigationService);
		}
	}
}
