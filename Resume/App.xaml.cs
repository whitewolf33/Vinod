﻿using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Resume
{
	public partial class App : PrismApplication
	{
		public App()
		{
			InitializeComponent();
			NavigationService.NavigateAsync("NavigationPageEx/LoginPage");
		}

		protected override void OnInitialized()
		{
			InitializeComponent();
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<LoginPage>();
			Container.RegisterType<LoginPageViewModel>();

			Container.RegisterTypeForNavigation<MenuPage>();
			Container.RegisterType<MenuPageViewModel>();

			Container.RegisterTypeForNavigation<AboutMePage>();
			Container.RegisterType<AboutMePageViewModel>();

			Container.RegisterTypeForNavigation<QualificationsPage>();
			Container.RegisterType<QualificationsPageViewModel>();

			Container.RegisterTypeForNavigation<WorkExperiencePage>();
			Container.RegisterType<WorkExperiencePageViewModel>();

			Container.RegisterTypeForNavigation<ProjectDetailPage>();
			Container.RegisterType<ProjectDetailPageViewModel>();

			Container.RegisterTypeForNavigation<NavigationPageEx>();

			/**************** Instance Registration ***********/
			Container.RegisterInstance<IDataService>(new DataService());

		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
