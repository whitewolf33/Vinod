using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Resume
{
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();
            inappWebView.OnNavigationCompleted += (eventObj) => busyIndicator.IsRunning = busyIndicator.IsVisible = false;
		}
    }
}
