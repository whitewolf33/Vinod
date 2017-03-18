using System;
using Prism.Mvvm;
using Common;

namespace Resume
{
	public class Preference : BindableBase, IIndexed
	{
		public int Index { get; set; }

		public string Name { get; set; }

		string description;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}

		string _icon;
		public string Icon
		{
			get { return _icon; }
			set { SetProperty(ref _icon, value); }
		}

		public Action<Preference> PreferenceAction { get; set; }

	}
}
