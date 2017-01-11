﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;

namespace Resume
{
	public class DataService : BaseService, IDataService
	{

		TechnicalSkills cSharp = new TechnicalSkills { Name = "C#" };
		TechnicalSkills objC = new TechnicalSkills { Name = "Objective C" };
		TechnicalSkills xaml = new TechnicalSkills { Name = "XAML" };
		TechnicalSkills js = new TechnicalSkills { Name = "JavaScript" };
		TechnicalSkills html = new TechnicalSkills { Name = "HTML 5.0" };
		TechnicalSkills css = new TechnicalSkills { Name = "CSS 3.0" };
		TechnicalSkills asp = new TechnicalSkills { Name = "ASP" };
		TechnicalSkills aspMvc = new TechnicalSkills { Name = "ASP.Net MVC" };
		TechnicalSkills angJs = new TechnicalSkills { Name = "angularJS" };
		TechnicalSkills webApi = new TechnicalSkills { Name = "ASP.Net Web API" };
		TechnicalSkills jQuery = new TechnicalSkills { Name = "jQuery" };
		TechnicalSkills knockJs = new TechnicalSkills { Name = "Knockout.js" };
		TechnicalSkills winForms = new TechnicalSkills { Name = "WinForms" };
		TechnicalSkills wpf = new TechnicalSkills { Name = "WPF" };
		TechnicalSkills win8Apps = new TechnicalSkills { Name = "Win 8.1 Apps" };
		TechnicalSkills uwp = new TechnicalSkills { Name = "UWP" };
		TechnicalSkills iOS = new TechnicalSkills { Name = "iOS" };
		TechnicalSkills android = new TechnicalSkills { Name = "Android" };
		TechnicalSkills wp8 = new TechnicalSkills { Name = "WP 8" };
		TechnicalSkills winCE = new TechnicalSkills { Name = "Windows CE 6.5" };
		TechnicalSkills tfs = new TechnicalSkills { Name = "TFS" };
		TechnicalSkills git = new TechnicalSkills { Name = "Git" };
		TechnicalSkills dotNet = new TechnicalSkills { Name = ".Net 4.5.1" };
		TechnicalSkills mono = new TechnicalSkills { Name = "Mono" };
		TechnicalSkills monoDroid = new TechnicalSkills { Name = "MonoDroid" };
		TechnicalSkills vs = new TechnicalSkills { Name = "Visual Studio" };
		TechnicalSkills xs = new TechnicalSkills { Name = "Xamarin Studio" };
		TechnicalSkills xcode = new TechnicalSkills { Name = "XCode" };
		TechnicalSkills sketch = new TechnicalSkills { Name = "Sketch" };
		TechnicalSkills invision = new TechnicalSkills { Name = "InvisionApp" };
		TechnicalSkills zepplin = new TechnicalSkills { Name = "Zepplin" };
		TechnicalSkills balsamiq = new TechnicalSkills { Name = "Balsamiq" };
		TechnicalSkills azure = new TechnicalSkills { Name = "Microsoft Azure" };
		TechnicalSkills testCloud = new TechnicalSkills { Name = "Xamarin Test Cloud" };
		TechnicalSkills xamTestRec = new TechnicalSkills { Name = "Xamarin Test Recorder" };
		TechnicalSkills nUnit = new TechnicalSkills { Name = "NUnit Unit Testing" };
		TechnicalSkills msUnit = new TechnicalSkills { Name = "MS Unit Testing" };
		TechnicalSkills specFlow = new TechnicalSkills { Name = "SpecFlow API Testing" };
		TechnicalSkills waterFall = new TechnicalSkills { Name = "Waterfall" };
		TechnicalSkills scrum = new TechnicalSkills { Name = "Agile - Scrum" };
		TechnicalSkills kanban = new TechnicalSkills { Name = "Agile - Kanban" };
		TechnicalSkills sql = new TechnicalSkills { Name = "SQL Server" };
		TechnicalSkills sqlite = new TechnicalSkills { Name = "SQLite" };

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
				programGroup.Add(cSharp);
				programGroup.Add(objC);

				GroupedDisplay scriptGroup = new GroupedDisplay { GroupName = "Scripting Language" };
				scriptGroup.Add(xaml);
				scriptGroup.Add(js);
				scriptGroup.Add(html);
				scriptGroup.Add(css);
				scriptGroup.Add(asp);

				GroupedDisplay webGroup = new GroupedDisplay { GroupName = "Web Technology" };
				webGroup.Add(aspMvc);
				webGroup.Add(angJs);
				webGroup.Add(aspMvc);
				webGroup.Add(jQuery);
				webGroup.Add(knockJs);

				GroupedDisplay windowsGroup = new GroupedDisplay { GroupName = "Windows Technology" };
				windowsGroup.Add(winForms);
				windowsGroup.Add(wpf);
				windowsGroup.Add(win8Apps);

				GroupedDisplay mobileGroup = new GroupedDisplay { GroupName = "Mobile Technology" };
				mobileGroup.Add(iOS);
				mobileGroup.Add(android);
				mobileGroup.Add(wp8);
				mobileGroup.Add(uwp);
				mobileGroup.Add(winCE);

				GroupedDisplay dbGroup = new GroupedDisplay { GroupName = "Database" };
				dbGroup.Add(sql);
				dbGroup.Add(sqlite);

				GroupedDisplay sourceControlGroup = new GroupedDisplay { GroupName = "Source Control" };
				sourceControlGroup.Add(tfs);
				sourceControlGroup.Add(git);

				GroupedDisplay frameworkGroup = new GroupedDisplay { GroupName = "Framework" };
				frameworkGroup.Add(dotNet);
				frameworkGroup.Add(mono);
				frameworkGroup.Add(monoDroid);
				frameworkGroup.Add(winCE);

				GroupedDisplay devToolsGroup = new GroupedDisplay { GroupName = "Development Tools" };
				devToolsGroup.Add(vs);
				devToolsGroup.Add(xs);
				devToolsGroup.Add(xcode);

				GroupedDisplay designToolsGroup = new GroupedDisplay { GroupName = " UX Tools" };
				designToolsGroup.Add(sketch);
				designToolsGroup.Add(invision);
				designToolsGroup.Add(zepplin);
				designToolsGroup.Add(balsamiq);

				GroupedDisplay cloudGroup = new GroupedDisplay { GroupName = "Cloud Solutions" };
				cloudGroup.Add(azure);

				GroupedDisplay testingGroup = new GroupedDisplay { GroupName = "Testing Frameworks & Tools" };
				testingGroup.Add(testCloud);
				testingGroup.Add(xamTestRec);
				testingGroup.Add(nUnit);
				testingGroup.Add(msUnit);
				testingGroup.Add(specFlow);

				GroupedDisplay devMethodGroup = new GroupedDisplay { GroupName = "Development Methodology" };
				devMethodGroup.Add(waterFall);
				devMethodGroup.Add(scrum);
				devMethodGroup.Add(kanban);

				List<GroupedDisplay> techGroupsList = new List<GroupedDisplay>();
				techGroupsList.Add(programGroup);
				techGroupsList.Add(scriptGroup);
				techGroupsList.Add(webGroup);
				techGroupsList.Add(windowsGroup);
				techGroupsList.Add(mobileGroup);
				techGroupsList.Add(dbGroup);
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

		public async Task<List<Project>> GetProjectsList()
		{
			return new List<Project>();
		}
	}
}
