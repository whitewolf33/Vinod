using System;
using System.Collections.ObjectModel;

namespace Resume
{
	public class GroupedDisplay : ObservableCollection<IGroupable>
	{
		public string GroupName { get; set; }
	}
}
