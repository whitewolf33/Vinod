using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Resume.Helpers;
using Xamarin.Forms;

namespace Resume
{
	public class DataService : BaseService, IDataService
	{

		#region Technical Skills
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
		TechnicalSkills dotNetCore = new TechnicalSkills { Name = ".Net Core" };
		TechnicalSkills mono = new TechnicalSkills { Name = "Xamarin.iOS" };
		TechnicalSkills monoDroid = new TechnicalSkills { Name = "Xamarin.Droid" };
		TechnicalSkills xamForms = new TechnicalSkills { Name = "Xamarin Forms" };
		TechnicalSkills vs = new TechnicalSkills { Name = "Visual Studio" };
		TechnicalSkills xs = new TechnicalSkills { Name = "Xamarin Studio" };
		TechnicalSkills xcode = new TechnicalSkills { Name = "XCode" };
		TechnicalSkills sketch = new TechnicalSkills { Name = "Sketch" };
		TechnicalSkills invision = new TechnicalSkills { Name = "InvisionApp" };
		TechnicalSkills zepplin = new TechnicalSkills { Name = "Zepplin" };
		TechnicalSkills balsamiq = new TechnicalSkills { Name = "Balsamiq" };
		TechnicalSkills azure = new TechnicalSkills { Name = "Microsoft Azure - PaaS, SaaS, IaaS" };
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
		#endregion


		#region Work

		WorkExperience _telstra;

		WorkExperience _city;

		WorkExperience _fred;

		WorkExperience _cadability;

		#endregion

		public static List<Project> Projects { get; set; } = new List<Project>();

		public DataService()
		{

			_telstra = new WorkExperience
			{
				Index = 1,
				Company = "Telstra Health",
				Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
				StartDate = new DateTime(2015, 12, 07),
				EndDate = DateTime.Today,
				Latitude = -37.8106622,
				Longitude = 144.9635376,
				CompanyLogo = "thealth.png"
			};
			_city = new WorkExperience
			{
				Index = 2,
				Company = "City Holdings Aus Pty Ltd",
				Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
				StartDate = new DateTime(2015, 06, 01),
				EndDate = new DateTime(2015, 12, 01),
				Latitude = -37.9194124,
				Longitude = 145.1577831,
				CompanyLogo = "city.png"
			};
			_fred = new WorkExperience
			{
				Index = 3,
				Company = "FRED IT Group",
				Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
				StartDate = new DateTime(2008, 01, 01),
				EndDate = new DateTime(2015, 01, 01),
				Latitude = -37.7993071,
				Longitude = 144.9976491,
				CompanyLogo = "fred.png"
			};
			_cadability = new WorkExperience
			{
				Index = 4,
				Company = "Cadability Pty Ltd",
				Address = " Level 3, 222, QV Building, Melbourne, VIC - 3000",
				StartDate = new DateTime(2008, 01, 01),
				EndDate = new DateTime(2015, 06, 01),
				Latitude = -37.7993071,
				Longitude = 144.9976491,
				CompanyLogo = "fred.png"
			};

			Project cpc = new Project();
			cpc.Name = "Care Plan Connect";
			cpc.Logo = "cpc.png";
			cpc.StartDate = new DateTime(2015, 12, 01);
			cpc.EndDate = new DateTime(2016, 06, 01);
			//cpc.Duration = "Dec 2015 - June 2016";

			cpc.ShortDescription = "iOS and Android App";
			cpc.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//cpc.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			cpc.Technologies = new List<TechnicalSkills>
					{
						xamForms,webApi, azure, sql, sqlite
					};
			cpc.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			cpc.Company = _telstra;
			_telstra.Projects.Add(cpc);

			Project cc = new Project();
			cc.Name = "Consumer Channel";
			cc.Logo = "consumerchannel.png";
			cpc.StartDate = new DateTime(2016, 07, 01);
			cpc.EndDate = new DateTime(2016, 09, 01);
			//cc.Duration = "July 2016 - September 2016";

			cc.ShortDescription = "iOS and Android App";
			cc.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//cc.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			cc.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			cc.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			cc.Company = _telstra;
			_telstra.Projects.Add(cc);

			Project hg = new Project();
			hg.Name = "HealthNow";
			hg.Logo = "healthgateway.png";
			hg.StartDate = new DateTime(2016, 09, 01);
			hg.EndDate = DateTime.Today;
			//hg.Duration = "September 2016 - Till date";
			hg.ShortDescription = "iOS and Android App";
			hg.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			hg.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			hg.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			hg.Company = _telstra;
			_telstra.Projects.Add(hg);

			Project myAssets = new Project();
			myAssets.Name = "MyAssets";
			myAssets.Logo = "healthgateway.png";
			myAssets.StartDate = new DateTime(2015, 06, 01);
			myAssets.EndDate = new DateTime(2015, 08, 01);
			//myAssets.Duration = "September 2016 - Till date";
			myAssets.ShortDescription = "iOS and Android App";
			myAssets.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			myAssets.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			myAssets.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			myAssets.Company = _city;
			_city.Projects.Add(myAssets);

			Project myFM = new Project();
			myFM.Name = "MyFM";
			myFM.Logo = "healthgateway.png";
			myFM.StartDate = new DateTime(2015, 06, 01);
			myFM.EndDate = new DateTime(2015, 08, 01);
			myFM.ShortDescription = "iOS and Android App";
			myFM.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			myFM.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			myFM.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			myFM.Company = _city;
			_city.Projects.Add(myFM);


			Project myAvailability = new Project();
			myAvailability.Name = "MyAvailability";
			myAvailability.Logo = "healthgateway.png";
			myAvailability.StartDate = new DateTime(2015, 06, 01);
			myAvailability.EndDate = new DateTime(2015, 08, 01);
			//myAvailability.Duration = "September 2016 - Till date";
			myAvailability.ShortDescription = "iOS and Android App";
			myAvailability.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			myAvailability.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			myAvailability.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			myAvailability.Company = _city;
			_city.Projects.Add(myAvailability);

			Project fredNxtOffice = new Project();
			fredNxtOffice.Name = "Fred Nxt Office";
			fredNxtOffice.Logo = "healthgateway.png";
			fredNxtOffice.StartDate = new DateTime(2015, 06, 01);
			fredNxtOffice.EndDate = new DateTime(2015, 08, 01);
			//fredNxtOffice.Duration = "September 2016 - Till date";
			fredNxtOffice.ShortDescription = "iOS and Android App";
			fredNxtOffice.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			fredNxtOffice.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			fredNxtOffice.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			fredNxtOffice.Company = _fred;
			_fred.Projects.Add(fredNxtOffice);


			Project fredOffice = new Project();
			fredOffice.Name = "Fred Office";
			fredOffice.Logo = "healthgateway.png";
			fredOffice.StartDate = new DateTime(2015, 06, 01);
			fredOffice.EndDate = new DateTime(2015, 08, 01);
			//fredOffice.Duration = "September 2016 - Till date";
			fredOffice.ShortDescription = "iOS and Android App";
			fredOffice.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			fredOffice.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			fredOffice.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			fredOffice.Company = _fred;
			_fred.Projects.Add(fredOffice);

			Project fredRapid = new Project();
			fredRapid.Name = "Fred Rapid";
			fredRapid.Logo = "healthgateway.png";
			fredRapid.StartDate = new DateTime(2015, 06, 01);
			fredRapid.EndDate = new DateTime(2015, 08, 01);
			//fredRapid.Duration = "September 2016 - Till date";
			fredRapid.ShortDescription = "iOS and Android App";
			fredRapid.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			fredRapid.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			fredRapid.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			fredRapid.Company = _fred;
			_fred.Projects.Add(fredRapid);

			Project scoringSystem = new Project();
			scoringSystem.Name = "Data Capture Systems";
			scoringSystem.Logo = "healthgateway.png";
			scoringSystem.StartDate = new DateTime(2015, 06, 01);
			scoringSystem.EndDate = new DateTime(2015, 08, 01);
			//scoringSystem.Duration = "September 2016 - Till date";
			scoringSystem.ShortDescription = "iOS and Android App";
			scoringSystem.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			scoringSystem.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			scoringSystem.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			scoringSystem.Company = _cadability;
			_cadability.Projects.Add(scoringSystem);

			Project delivery = new Project();
			delivery.Name = "Data Delivery Systems";
			delivery.Logo = "healthgateway.png";
			delivery.StartDate = new DateTime(2015, 06, 01);
			delivery.EndDate = new DateTime(2015, 08, 01);
			//delivery.Duration = "September 2016 - Till date";
			delivery.ShortDescription = "iOS and Android App";
			delivery.Description = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			//hg.Technology = "Xamarin Forms, Web API, Azure PaaS SQL Server";
			delivery.Technologies = new List<TechnicalSkills> { xamForms, webApi, azure, sql };
			delivery.Responsibility = "Care Plan Connect is a smarter way of helping Type 2 Diabetes patients keep their blood sugar level under control.....";
			delivery.Company = _cadability;
			_cadability.Projects.Add(delivery);

			Projects = _telstra.Projects.Union(_city.Projects).Union(_fred.Projects).Union(_cadability.Projects).ToList();
		}

		public async Task<List<Timeline>> GetTimeline()
		{
			var timelineList = new List<Timeline>();
			timelineList.Add(new Timeline { Id = 1, Year = 1983, Title = "Born", SubTitle = "Chennai, India" });
			timelineList.Add(new Timeline { Id = 2, Year = 2004, Title = "B.Tech I.T.", SubTitle = "University of Madras, India" });
			timelineList.Add(new Timeline { Id = 3, Year = 2006, Title = "M.Tech I.T.", SubTitle = "R.M.I.T, Melblourne, Australia" });
			timelineList.Add(new Timeline { Id = 4, Year = 2008, Title = "FRED I.T.", SubTitle = "Development Consultant" });
			timelineList.Add(new Timeline { Id = 5, Year = 2012, Title = "FRED I.T.", SubTitle = "Development Team Lead" });
			timelineList.Add(new Timeline { Id = 6, Year = 2015, Title = "FRED I.T.", SubTitle = "Senior Development Consultant" });
			timelineList.Add(new Timeline { Id = 7, Year = 2015, Title = "City Holdings", SubTitle = "Xamarin Developer" });
			timelineList.Add(new Timeline { Id = 8, Year = 2015, Title = "Telstra Health", SubTitle = "Senior Technical Specialist" });

			return await Task.FromResult(timelineList);
		}

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

				GroupedDisplay frameworkGroup = new GroupedDisplay { GroupName = "Cross Platform" };
				frameworkGroup.Add(dotNetCore);
				frameworkGroup.Add(mono);
				frameworkGroup.Add(monoDroid);
				frameworkGroup.Add(xamForms);

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
					workExperiences.Add(_telstra);
					workExperiences.Add(_city);
					workExperiences.Add(_fred);
					workExperiences.Add(_cadability);

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
			return await Task.Run(() =>
			{
				try
				{
					return Projects;
				}
				catch (Exception ex)
				{
					MyInsights.Report(ex);
					return new List<Project>();
				}
			});
		}

		public async Task<List<Preference>> GetPreferences()
		{
			return await Task.Run(() =>
			{
				try
				{
					List<Preference> preferences = new List<Preference>();
					preferences.Add(new Preference
					{
						Name = "Enable TouchID",
						Description = Constants.TouchID.DisabledDesc,
						Icon = Settings.UseTouchID ? Constants.TouchID.EnabledIcon : Constants.TouchID.DisabledIcon,
						PreferenceAction = new Action<Preference>(async (pref) => { await SetupTouchID(pref); })
					});
					preferences.Add(new Preference
					{
						Name = "Print Resume",
						Description = "Tap to send this resume to a printer in your network",
						Icon = "print.png",
						PreferenceAction = new Action<Preference>((pref) =>
						{
							var printService = Xamarin.Forms.DependencyService.Get<IPrintService>();
							if (printService != null)
							{
								Device.BeginInvokeOnMainThread(() => printService.Print());
							}
						})
					});
					preferences.Add(new Preference { Name = "Share Resume", Description = "Tap to share this resume with others via email or social media", Icon = "share.png" });
					preferences.Add(new Preference { Name = "Your favourites & notes", Description = "Tap to view your favourires and notes saved in this app", Icon = "favourite.png" });
					return preferences;
				}
				catch (Exception ex)
				{
					MyInsights.Report(ex);
					return new List<Preference>();
				}
			});
		}

		private async Task SetupTouchID(Preference pref)
		{
			await Task.Run(async () =>
			{
				bool touchIdAvailable = await Acr.Biometrics.Biometrics.Instance.IsAvailable();
				touchIdAvailable = true;
				if (touchIdAvailable)
				{
					// Toggle TouchID Enabled
					Settings.UseTouchID = !Settings.UseTouchID;
				}
				else
				{
					//Throw error Msg 
				}

				pref.Icon = Settings.UseTouchID ? Constants.TouchID.EnabledIcon : Constants.TouchID.DisabledIcon;
				pref.Description = Settings.UseTouchID ? Constants.TouchID.EnabledDesc : Constants.TouchID.DisabledDesc;
			});
		}
	}
}

