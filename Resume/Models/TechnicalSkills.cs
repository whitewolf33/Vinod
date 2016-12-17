using System;
using System.Collections.ObjectModel;

namespace Resume
{

	public class TechnicalSkills : IGroupable
	{
		public string Name { get; set; }

		public int Strength { get; set; }

		public int Years { get; set; }
	}
}
