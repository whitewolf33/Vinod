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
			
			var fullPath =Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/resume.pdf";
			bool exists = File.Exists(fullPath);

			if (exists)
			{
				var pdf = NSData.FromFile(fullPath);
				// Get a reference to the singleton iOS printing concierge
				UIPrintInteractionController printController = UIPrintInteractionController.SharedPrintController;
				printController.PrintingItem = pdf;
				// Instruct the printing concierge to use our custom UIPrintPageRenderer subclass when printing this job
				printController.PrintPageRenderer = new PrintPageRenderer();

				// Ask for a print job object and configure its settings to tailor the print request
				UIPrintInfo info = UIPrintInfo.PrintInfo;

				// B&W or color, normal quality output for mixed text, graphics, and images
				info.OutputType = UIPrintInfoOutputType.General;

				// Select the job named this in the printer queue to cancel our print request.
				info.JobName = "Resume";

				// Instruct the printing concierge to use our custom print job settings.
				printController.PrintInfo = info;

				// Present the standard iOS Print Panel that allows you to pick the target Printer, number of pages, double-sided, etc.

				printController.Present(true, PrintingCompleted);
			}

		}

		void PrintingCompleted(UIPrintInteractionController controller, bool completed, NSError error)
		{

		}
	}
}
