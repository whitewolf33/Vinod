using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Resume
{
	public class TechnicalSkillsPageViewModel : BaseViewModel
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

		double listViewRowHeight = 44;
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

		public TechnicalSkillsPageViewModel(INavigationService navigationService) : base(navigationService)
		{
			Task.Run(async () =>
			{
				var dataService = ((App)Application.Current).Container.Resolve<IDataService>();
				if (dataService != null)
					GroupedDisplayCollection = await dataService.GetTechnicalSkills();
			});
		}
	}
}

