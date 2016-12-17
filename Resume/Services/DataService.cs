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

		public async Task<List<GroupedDisplay>> GetTechnicalSkills()
		{
			return await Task.Run(() =>
			{
				GroupedDisplay programGroup = new GroupedDisplay { GroupName = "Programming Language" };
				programGroup.Add(new TechnicalSkills { Name = "C#" });
				programGroup.Add(new TechnicalSkills { Name = "Objective C" });

				GroupedDisplay scriptGroup = new GroupedDisplay { GroupName = "Scripting Language" };
				scriptGroup.Add(new TechnicalSkills { Name = "XAML" });
				scriptGroup.Add(new TechnicalSkills { Name = "JavaScript" });
				scriptGroup.Add(new TechnicalSkills { Name = "HTML 5.0" });
				scriptGroup.Add(new TechnicalSkills { Name = "CSS 3.0" });
				scriptGroup.Add(new TechnicalSkills { Name = "ASP" });

				GroupedDisplay webGroup = new GroupedDisplay { GroupName = "Web Technology" };
				webGroup.Add(new TechnicalSkills { Name = "ASP.Net MVC" });
				webGroup.Add(new TechnicalSkills { Name = "angularJS" });
				webGroup.Add(new TechnicalSkills { Name = "ASP.Net Web API" });
				webGroup.Add(new TechnicalSkills { Name = "jQuery" });
				webGroup.Add(new TechnicalSkills { Name = "Knockout.js" });

				GroupedDisplay windowsGroup = new GroupedDisplay { GroupName = "Windows Technology" };
				windowsGroup.Add(new TechnicalSkills { Name = "WinForms" });
				windowsGroup.Add(new TechnicalSkills { Name = "WPF" });
				windowsGroup.Add(new TechnicalSkills { Name = "Win 8.1 Apps" });
				windowsGroup.Add(new TechnicalSkills { Name = "UWP" });

				GroupedDisplay mobileGroup = new GroupedDisplay { GroupName = "Mobile Technology" };
				mobileGroup.Add(new TechnicalSkills { Name = "iOS" });
				mobileGroup.Add(new TechnicalSkills { Name = "Android" });
				mobileGroup.Add(new TechnicalSkills { Name = "WP 8" });
				mobileGroup.Add(new TechnicalSkills { Name = "UWP" });
				mobileGroup.Add(new TechnicalSkills { Name = "Windows CE 6.5" });

				GroupedDisplay sourceControlGroup = new GroupedDisplay { GroupName = "Source Control" };
				sourceControlGroup.Add(new TechnicalSkills { Name = "TFS" });
				sourceControlGroup.Add(new TechnicalSkills { Name = "Git" });

				GroupedDisplay frameworkGroup = new GroupedDisplay { GroupName = "Framework" };
				frameworkGroup.Add(new TechnicalSkills { Name = ".Net 4.5.1" });
				frameworkGroup.Add(new TechnicalSkills { Name = "MonoTouch" });
				frameworkGroup.Add(new TechnicalSkills { Name = "MonoDroid" });
				frameworkGroup.Add(new TechnicalSkills { Name = ".Net CF 3.5" });

				GroupedDisplay devToolsGroup = new GroupedDisplay { GroupName = "Development Tools" };
				devToolsGroup.Add(new TechnicalSkills { Name = "Visual Studio" });
				devToolsGroup.Add(new TechnicalSkills { Name = "Xamarin Studio" });

				GroupedDisplay designToolsGroup = new GroupedDisplay { GroupName = " UX Tools" };
				designToolsGroup.Add(new TechnicalSkills { Name = "Sketch" });
				designToolsGroup.Add(new TechnicalSkills { Name = "InvisionApp" });
				designToolsGroup.Add(new TechnicalSkills { Name = "Zepplin" });
				designToolsGroup.Add(new TechnicalSkills { Name = "Balsamiq" });

				GroupedDisplay cloudGroup = new GroupedDisplay { GroupName = "Cloud Solutions" };
				cloudGroup.Add(new TechnicalSkills { Name = "Microsoft Azure" });

				GroupedDisplay testingGroup = new GroupedDisplay { GroupName = "Testing Frameworks & Tools" };
				testingGroup.Add(new TechnicalSkills { Name = "Xamarin Test Cloud" });
				testingGroup.Add(new TechnicalSkills { Name = "Xamarin Test Recorder" });
				testingGroup.Add(new TechnicalSkills { Name = "NUnit Unit Testing" });
				testingGroup.Add(new TechnicalSkills { Name = "MS Unit Testing" });
				testingGroup.Add(new TechnicalSkills { Name = "SpecFlow API Testing" });

				GroupedDisplay devMethodGroup = new GroupedDisplay { GroupName = "Development Methodology" };
				devMethodGroup.Add(new TechnicalSkills { Name = "Visual Studio" });
				devMethodGroup.Add(new TechnicalSkills { Name = "Xamarin Studio" });
				devMethodGroup.Add(new TechnicalSkills { Name = "XCode" });

				List<GroupedDisplay> techGroupsList = new List<GroupedDisplay>();
				techGroupsList.Add(programGroup);
				techGroupsList.Add(scriptGroup);
				techGroupsList.Add(webGroup);
				techGroupsList.Add(windowsGroup);
				techGroupsList.Add(mobileGroup);
				techGroupsList.Add(sourceControlGroup);
				techGroupsList.Add(frameworkGroup);
				techGroupsList.Add(devToolsGroup);
				techGroupsList.Add(designToolsGroup);
				techGroupsList.Add(cloudGroup);
				techGroupsList.Add(testingGroup);
				techGroupsList.Add(devMethodGroup);

				return techGroupsList;
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
					cpc.Logo = "cpc.png";
					cpc.Duration = "Dec 2015 - June 2016";

					cpc.ShortDescription = "iOS and Android App";
					cpc.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					cpc.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
					cpc.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					projects.Add(cpc);

					Project cc = new Project();
					cc.Name = "Consumer Channel";
					cc.Logo = "consumerchannel.png";
					cc.Duration = "July 2016 - September 2016";

					cc.ShortDescription = "iOS and Android App";
					cc.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					cc.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
					cc.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					projects.Add(cc);

					Project hg = new Project();
					hg.Name = "HealthGateway";
					hg.Logo = "healthgateway.png";
					hg.Duration = "September 2016 - Till date";
					hg.ShortDescription = "iOS and Android App";
					hg.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
					hg.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
					projects.Add(hg);

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
