using Microsoft.Practices.Unity;
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
			Container.RegisterType<AboutMePageViewModel>(new ContainerControlledLifetimeManager());

			Container.RegisterTypeForNavigation<QualificationsPage>();
			Container.RegisterType<QualificationsPageViewModel>(new ContainerControlledLifetimeManager());

			Container.RegisterTypeForNavigation<WorkExperiencePage>();
			Container.RegisterType<WorkExperiencePageViewModel>(new ContainerControlledLifetimeManager());

			Container.RegisterTypeForNavigation<ProjectDetailPage>();
			Container.RegisterType<ProjectDetailPageViewModel>(new ContainerControlledLifetimeManager());

			Container.RegisterTypeForNavigation<PreferencesPage>();
			Container.RegisterType<PreferencesPageViewModel>();

			Container.RegisterTypeForNavigation<NavigationPageEx>();

			/**************** Instance Registration ***********/
			Container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());

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
