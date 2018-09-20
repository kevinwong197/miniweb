using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace miniweb
{
    public sealed partial class MainPage : Page
    {
        public string urlstr = "https://google.com";

        public MainPage()
        {
            this.InitializeComponent();
        }

        async private void Disable_Scroll_Visible(Windows.UI.Xaml.Controls.WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            await webView.InvokeScriptAsync("eval", new string[] { "document.documentElement.style.msOverflowStyle = 'none';" });
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (e.Parameter is string && ((string)e.Parameter).Length != 0)
                {
                    webView.Navigate(new Uri((string)e.Parameter));
                }
                else
                {
                    webView.Navigate(new Uri("https://google.com"));
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Something Happened").ShowAsync();
                Application.Current.Exit();
            }
        }
    }
}
