using System;
using System.ComponentModel;
using Common;
using Foundation;
using Resume.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LineEntry), typeof(LineEntryRenderer))]
namespace Resume.iOS
{
	public class LineEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.BorderStyle = UITextBorderStyle.None;
				Control.EnablesReturnKeyAutomatically = true;
				//Control.ClearButtonMode = UITextFieldViewMode.WhileEditing;

				var view = (Element as LineEntry);
				if (view != null)
				{
					Control.ReturnKeyType = String.IsNullOrWhiteSpace(view.ReturnKeyText) ? UIReturnKeyType.Default : MapReturnKeyType(view.ReturnKeyText);

					DrawBorder(view);
					//SetFontSize(view);
					SetPlaceholderTextColor(view);

				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var view = (LineEntry)Element;

			if (e.PropertyName.Equals(view.BorderColor))
				DrawBorder(view);
			//if (e.PropertyName.Equals(view.FontSize))
			//	SetFontSize(view);
			if (e.PropertyName.Equals(view.PlaceholderColor))
				SetPlaceholderTextColor(view);
		}

		void DrawBorder(LineEntry view)
		{
			Control.BorderStyle = UITextBorderStyle.None;
			//if (view.BackgroundColor != Color.Transparent)
			//{
			//	var borderLayer = new CALayer();
			//	borderLayer.MasksToBounds = true;
			//	borderLayer.Frame = new CoreGraphics.CGRect(0f, 21f, (Frame.Width - 60), 1f);
			//	borderLayer.BorderColor = view.BorderColor.ToCGColor();
			//	borderLayer.BorderWidth = 1.0f;

			//	Control.Layer.AddSublayer(borderLayer);
			//}
		}

		void SetFontSize(LineEntry view)
		{
			if (view.FontSize != Font.Default.FontSize)
				Control.Font = UIFont.SystemFontOfSize((System.nfloat)view.FontSize);
			else if (view.FontSize == Font.Default.FontSize)
				Control.Font = UIFont.SystemFontOfSize(17f);
		}

		void SetPlaceholderTextColor(LineEntry view)
		{
			if (!string.IsNullOrEmpty(view.Placeholder) && view.PlaceholderColor != Color.Default)
			{
				var placeholderString = new NSAttributedString(view.Placeholder,
											new UIStringAttributes { ForegroundColor = view.PlaceholderColor.ToUIColor() });
				Control.AttributedPlaceholder = placeholderString;
			}
		}

		UIReturnKeyType MapReturnKeyType(string returnKeyText)
		{
			switch (returnKeyText)
			{
				case "Done":
					return UIReturnKeyType.Done;
				case "Next":
					return UIReturnKeyType.Next;
				case "Continue":
					return UIReturnKeyType.Continue;
				case "Search":
					return UIReturnKeyType.Search;
				case "Go":
					return UIReturnKeyType.Go;
				case "Send":
					return UIReturnKeyType.Send;
				default:
					return UIReturnKeyType.Default;
			}
		}
	}
}

