using System.Collections.Generic;

namespace Resume
{
	public class Project
	{
		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string Duration { get; set; }

		public string Description { get; set; }

		public string Technology
		{
			get { return string.Join(", ", Technologies); }
		}

		public WorkExperience Company { get; set; }

		public List<TechnicalSkills> Technologies { get; set; }

		public string Responsibility { get; set; }

		public string Logo { get; set; }
	}
}
