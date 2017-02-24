using System;
using Prism.Mvvm;

namespace Resume
{
	public class ProjectViewViewModel : BindableBase
	{

		Project _project;

		public Project Project
		{
			get { return _project; }
			set { SetProperty(ref _project, value); }
		}
	}
}
