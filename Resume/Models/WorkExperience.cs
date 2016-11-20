using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Resume
{
	public class WorkExperience
	{
		public string Company { get; set; }

		public string Address { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public string WorkPeriod { get; set; }

		public string CompanyLogo { get; set; }

		public List<Project> Projects { get; set; }

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
