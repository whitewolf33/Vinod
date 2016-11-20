using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;

namespace Resume
{
	public class QualificationsViewViewModel : BaseViewModel
	{
		List<GroupedDisplay> _groupedDisplayCollection;

		public List<GroupedDisplay> GroupedDisplayCollection
		{
			get
			{
				return _groupedDisplayCollection;
			}

			set
			{
				_groupedDisplayCollection = value;

				OnPropertyChanged("GroupedDisplayCollection");
			}
		}

		double listViewRowHeight = 100;
		public double ListViewRowHeight
		{
			get
			{
				return listViewRowHeight;
			}

			set
			{
				listViewRowHeight = value;
			}
		}

		double listViewHeight;

		public double ListViewHeight
		{
			get
			{
				return listViewHeight;
			}

			set
			{
				listViewHeight = value;
			}
		}

		public QualificationsViewViewModel(INavigationService navigationService) : base(navigationService)
		{
			Task.Run(async () =>
			{
				var dataService = ((App)Application.Current).Container.Resolve<IDataService>();
				if (dataService != null)
					GroupedDisplayCollection = await dataService.GetQualifications();
			});
		}
	}
}
