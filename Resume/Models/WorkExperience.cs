using System.Collections.Generic;
using Common;
using System;

namespace Resume
{
	public class WorkExperience : IPage
	{
		public int Index { get; set; }

		public string Company { get; set; }

		public string Address { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string WorkPeriod { get { return String.Format("{0} - {1}", StartDate.ToString("MMM yyyy"), EndDate.ToString("MMM yyyy")); } }

		public string CompanyLogo { get; set; }

		public List<Project> Projects { get; set; } = new List<Project>();

		public Location CompanyLocation
		{
			get
			{
				var companyLoc = new Location();
				companyLoc.Name = Company;
				companyLoc.Latitude = Latitude;
				companyLoc.Longitude = Longitude;
				return companyLoc;
			}
		}
	}

	public class Location
	{
		public string Name { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

	}
}
