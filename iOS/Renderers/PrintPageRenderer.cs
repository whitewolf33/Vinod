using System;
using CoreGraphics;
using Foundation;
using UIKit;
using CoreFoundation;
using Xamarin.Forms;
using Resume.iOS;


namespace Resume.iOS
{
	public class PrintPageRenderer : UIPrintPageRenderer
	{
		const float RecipeInfoHeight = 150.0f;
		const float TitleSize = 24.0f;
		const float Padding = 10.0f;

		static UIFont SystemFont = UIFont.SystemFontOfSize(UIFont.SystemFontSize);
		NSRange pageRange;

		public PrintPageRenderer()
		{
			this.HeaderHeight = 20.0f;
			this.FooterHeight = 20.0f;
		}

		// Calculate the content area based on the printableRect, that is, the area in which
		// the printer can print content. a.k.a the imageable area of the paper.
		CGRect ContentArea
		{
			get
			{
				CGRect r = PrintableRect;
				r.Height -= HeaderHeight + FooterHeight;
				r.Y += HeaderHeight;
				return r;
			}
		}

		public override void PrepareForDrawingPages(NSRange range)
		{
			DispatchQueue.MainQueue.DispatchSync(() =>
			{
				base.PrepareForDrawingPages(range);
				pageRange = range;
			});
		}

		// This property must be overriden when doing custom drawing as we are.
		// Since our custom drawing is really only for the borders and we are
		// relying on a series of UIMarkupTextPrintFormatters to display the recipe
		// content, UIKit can calculate the number of pages based on informtation
		// provided by those formatters.
		//
		// Therefore, setup the formatters, and ask super to count the pages.
		// HACK: Changed overridden member int to nint
		public override nint NumberOfPages
		{
			get
			{
				nint pages = 0;
				DispatchQueue.MainQueue.DispatchSync(() =>
				{
					SetupPrintFormatters();

					pages = base.NumberOfPages;

				});
				return pages;

			}
		}

		// Iterate through the recipes setting each of their html representations into
		// a UIMarkupTextPrintFormatter and add that formatter to the printing job.
		void SetupPrintFormatters()
		{
			CGRect contentArea = ContentArea;
			nfloat previousFormatterMaxY = contentArea.Top;
			nint page = 0;


			{
				string html = "<!DOCTYPE html>\n<html>\n<body>\n\n<p>This is a paragraph.</p>\n<p>This is a paragraph.</p>\n<p>This is a paragraph.</p>\n\n</body>\n</html>";

				// ios9 calls NumberOfPages -> SetupPrintFormatters not from main thread, but UIMarkupTextPrintFormatter is UIKit class (must be accessed from main thread)


				try
				{
					var formatter = new UIMarkupTextPrintFormatter(html);

					// Make room for the recipe info
					UIEdgeInsets contentInsets = UIEdgeInsets.Zero;

					contentInsets.Top = previousFormatterMaxY + RecipeInfoHeight;
					if (contentInsets.Top > contentArea.Bottom)
					{
						// Move to the next page
						contentInsets.Top = contentArea.Top + RecipeInfoHeight;
						page++;
					}

					formatter.ContentInsets = contentInsets;

					// Add the formatter to the renderer at the specified page
					AddPrintFormatter(formatter, page);

					page = formatter.StartPage + formatter.PageCount - 1;

					previousFormatterMaxY = formatter.RectangleForPage(page).Bottom;
				}
				catch (Exception ex)
				{

				}

			}
		}

		// Custom UIPrintPageRenderer's may override this class to draw a custom print page header.
		// To illustrate that, this class sets the date in the header.
		public override void DrawHeaderForPage(nint index, CGRect headerRect)
		{
			NSDateFormatter dateFormatter = new NSDateFormatter();
			dateFormatter.DateFormat = "MMMM d, yyyy 'at' h:mm a";

			NSString dateString = new NSString(dateFormatter.ToString(NSDate.Now));
			dateFormatter.Dispose();

			dateString.DrawString(headerRect, SystemFont, UILineBreakMode.Clip, UITextAlignment.Right);
			dateString.Dispose();
		}

		public override void DrawFooterForPage(nint index, CGRect footerRect)
		{
			NSString footer = new NSString(string.Format("Page {0} of {1}", index - pageRange.Location + 1, pageRange.Length));
			footer.DrawString(footerRect, SystemFont, UILineBreakMode.Clip, UITextAlignment.Center);
			footer.Dispose();
		}

		// To intermix custom drawing with the drawing performed by an associated print formatter,
		// this method is called for each print formatter associated with a given page.
		//
		// We do this to intermix/overlay our custom drawing onto the recipe presentation.
		// We draw the upper portion of the recipe presentation by hand (image, title, desc),
		// and the bottom portion is drawn via the UIMarkupTextPrintFormatter.
		public override void DrawPrintFormatterForPage(UIPrintFormatter printFormatter, nint page)
		{
			DispatchQueue.MainQueue.DispatchSync(() =>
				{
					base.DrawPrintFormatterForPage(printFormatter, page);

					// To keep our custom drawing in sync with the printFormatter, base our drawing
					// on the formatters rect.
					CGRect rect = printFormatter.RectangleForPage(page);

					// Use a bezier path to draw the borders.
					// We may potentially choose not to draw either the top or bottom line
					// of the border depending on whether our recipe extended from the previous
					// page, or carries onto the subsequent page.
					UIBezierPath border = new UIBezierPath();

					if (page == printFormatter.StartPage)
					{
						// For border drawing, get the rect that includes the formatter area plus the header area.
						// Move the formatter's rect up the size of the custom drawn recipe presentation
						// and essentially grow the rect's height by this amount.
						rect.Height += RecipeInfoHeight;
						rect.Y -= RecipeInfoHeight;

						border.MoveTo(rect.Location);
						border.AddLineTo(new CGPoint(rect.Right, rect.Top));

						// Run custom code to draw upper portion of the recipe presentation (image, title, desc)
						//DrawRecipe(recipe, rect);
					}

					// Draw the left border
					border.MoveTo(rect.Location);
					border.AddLineTo(new CGPoint(rect.Left, rect.Bottom));

					// Draw the right border
					border.MoveTo(new CGPoint(rect.Right, rect.Top));
					border.AddLineTo(new CGPoint(rect.Right, rect.Bottom));

					if (page == printFormatter.StartPage + printFormatter.PageCount - 1)
						border.AddLineTo(new CGPoint(rect.Left, rect.Bottom));

					// Set the UIColor to be used by the current graphics context, and then stroke
					// stroke the current path that is defined by the border bezier path.
					UIColor.Black.SetColor();
					border.Stroke();
				});
		}
	}
}
