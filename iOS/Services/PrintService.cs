using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Resume.iOS;
using CoreFoundation;
using System.IO;

[assembly: Dependency(typeof(PrintService))]
namespace Resume.iOS
{
	public class PrintService : IPrintService
	{
		public void Print()
		{
			UIPrintInteractionController printController = UIPrintInteractionController.SharedPrintController;
			printController.PrintingItem = NSUrl.FromString("https://vinodresume.azurewebsites.net/resume/");
			printController.ShowsPageRange = true;
			UIPrintInfo info = UIPrintInfo.PrintInfo;
			info.OutputType = UIPrintInfoOutputType.General;
			info.JobName = "Resume";
			printController.PrintInfo = info;
			printController.Present(true, PrintingCompleted);
		}

		void PrintingCompleted(UIPrintInteractionController controller, bool completed, NSError error)
		{

		}
	}
}
