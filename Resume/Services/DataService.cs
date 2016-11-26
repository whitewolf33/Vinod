using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;

namespace Resume
{
	public class DataService : BaseService, IDataService
	{
		public async Task<List<GroupedDisplay>> GetQualifications()
		{
			return await Task.Run(() =>
			{
				try
				{
					GroupedDisplay graduationGroup = new GroupedDisplay { GroupName = "Graduation" };
					Qualification masters = new Qualification { Degree = "Master of Technology - Information Technology", University = "rmit", Period = "2004-2006" };
					Qualification bachelors = new Qualification { Degree = "Bachelor of Technology - Information Technology", University = "unimad", Period = "2000-2004" };
					graduationGroup.Add(masters);
					graduationGroup.Add(bachelors);

					GroupedDisplay certificationGroup = new GroupedDisplay { GroupName = "Certifications" };
					certificationGroup.Add(new Qualification { Degree = "Xamarin Certified Mobile Developer", University = "xamuni", Period = "2015-2016" });
					certificationGroup.Add(new Qualification { Degree = "ASP.NET 4.5, MVC 4.0, Web Development", University = "microsoft", Period = "26-May-2014" });
					certificationGroup.Add(new Qualification { Degree = "SharePoint® 2010, Application Development", University = "microsoft", Period = "18-May-2012" });
					certificationGroup.Add(new Qualification { Degree = ".NET Framework 4, Data Access", University = "microsoft", Period = "27-Jan-2012" });
					certificationGroup.Add(new Qualification { Degree = "SQL Server® 2008, Implementation & Maintenance", University = "microsoft", Period = "12-Aug-2011" });
					certificationGroup.Add(new Qualification { Degree = "Microsoft Dynamics® AX 2009", University = "microsoft", Period = "29-Nov-2010" });
					certificationGroup.Add(new Qualification { Degree = ".NET Framework 4, Service Communication Applications", University = "microsoft", Period = "16-Aug-2010" });
					certificationGroup.Add(new Qualification { Degree = ".NET Framework 4, Windows® Applications", University = "microsoft", Period = "05-Jun-2010" });

					List<GroupedDisplay> certList = new List<GroupedDisplay>();
					certList.Add(graduationGroup);
					certList.Add(certificationGroup);
					return certList;
				}
				catch (Exception ex)
				{
					MyInsights.Report(ex);
					return new List<GroupedDisplay>();
				}
			});

		}


		public async Task<List<WorkExperience>> GetWorkExperiences()
		{
			return await Task.Run(() =>
			{
				try
				{
					List<WorkExperience> workExperiences = new List<WorkExperience>();
					var telstra = new WorkExperience
					{
						Index = 1,
						Company = "Telstra Health",
						Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
						WorkPeriod = "Dec 2015 - CURRENT",
						Latitude = -37.8106622,
						Longitude = 144.9635376,
						CompanyLogo = "thealth.png"
					};
					List<Project> projects = new List<Project>();

					Project cpc = new Project();
					cpc.Name = "Care Plan Connect";
					cpc.ShortDescription = "iOS and Android App";
					cpc.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					cpc.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
					cpc.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					projects.Add(cpc);

					Project cc = new Project();
					cc.Name = "Consumer Channel";
					cc.ShortDescription = "iOS and Android App";
					cc.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					cc.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
					cc.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					projects.Add(cc);

					Project hg = new Project();
					hg.Name = "HealthGateway";
					hg.ShortDescription = "iOS and Android App";
					hg.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
					hg.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					projects.Add(cc);

					telstra.Projects = projects;

					workExperiences.Add(telstra);

					var city = new WorkExperience
					{
						Index = 2,
						Company = "City Holdings Aus Pty Ltd",
						Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
						WorkPeriod = "Jun 2015 - Dec 2015",
						Latitude = -37.9194124,
						Longitude = 145.1577831,
						CompanyLogo = "city.png"
					};

					city.Projects = projects;
					workExperiences.Add(city);

					var fred = new WorkExperience
					{
						Index = 3,
						Company = "FRED IT Group",
						Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
						WorkPeriod = "Jan 2008 - Jun 2015",
						Latitude = -37.7993071,
						Longitude = 144.9976491,
						CompanyLogo = "fred.png"
					};

					List<Project> fredProjects = new List<Project>();
					fred.Projects = fredProjects;

					workExperiences.Add(fred);

					var cadability = new WorkExperience
					{
						Index = 4,
						Company = "Cadability Pty Ltd",
						Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
						WorkPeriod = "Jan 2008 - Jun 2015",
						Latitude = -37.7993071,
						Longitude = 144.9976491,
						CompanyLogo = "fred.png"
					};

					List<Project> cadProjects = new List<Project>();
					cadability.Projects = cadProjects;

					workExperiences.Add(cadability);

					return workExperiences;
				}
				catch (Exception ex)
				{
					MyInsights.Report(ex);
					return new List<WorkExperience>();
				}
			});
		}
	}
}
