using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Resume
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);

			codeOne.TextChanged += (s, e) => { if (!String.IsNullOrWhiteSpace(codeOne.Text)) codeTwo.Focus(); };
			codeTwo.TextChanged += (s, e) => { if (!String.IsNullOrWhiteSpace(codeTwo.Text)) codeThree.Focus(); };
			codeThree.TextChanged += (s, e) => { if (!String.IsNullOrWhiteSpace(codeThree.Text)) codeFour.Focus(); };
			codeFour.TextChanged += (s, e) => { if (!String.IsNullOrWhiteSpace(codeFour.Text)) codeFive.Focus(); };
			codeFive.TextChanged += (s, e) => { if (!String.IsNullOrWhiteSpace(codeFive.Text)) codeSix.Focus(); };
			codeSix.TextChanged += (s, e) =>
			{
				if (!String.IsNullOrWhiteSpace(codeSix.Text))
				{
					codeSix.Unfocus();
					if (buttonAuthenticate.Command.CanExecute(null))
						buttonAuthenticate.Command.Execute(null);
				}
			};
		}
	}
}
