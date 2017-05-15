using System.Collections.Generic;
using System;

namespace Resume
{
	public class Project
	{
		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string Description { get; set; }

		public string Technology
		{
			get { return string.Join(", ", Technologies); }
		}

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Duration { get { return String.Format("{0} - {1}", StartDate.ToString("MMM yyyy"), EndDate.ToString("MMM yyyy")); } }


		public WorkExperience Company { get; set; }

		public List<TechnicalSkills> Technologies { get; set; }

		public string Responsibility { get; set; }

		public string Logo { get; set; }
	}
}
