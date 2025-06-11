using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace bibKliWitkowski
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if (ApplicationData.Current.LocalSettings.Values["tryb"] != null)
            {
                if (Window.Current.Content is FrameworkElement rootElement)
                {
                    rootElement.RequestedTheme = (ElementTheme)ApplicationData.Current.LocalSettings.Values["tryb"];
                }
            }

            //test danych
           (App.Current as App).db.TestData();
            //db.TestData();
        }

        private async void btStronaWWW_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("http://ukw.edu.pl"));
        }

        private void btPomoc_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Help));
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var aktStrona = frmMain.CurrentSourcePageType;
            Type docStrona = null;

            if (args.IsSettingsInvoked == true)
            {
                //if (aktStrona == typeof(SettingsPage))
                //{
                //    return;
                //}
                NavView.Header = "wybrano: " + args.InvokedItemContainer.Name;
                docStrona = typeof(SettingsPage);
                //frmMain.Navigate(typeof(SettingsPage));
            }
            var wybrane = args.InvokedItemContainer.Name;
            switch (wybrane)
            {
                case "AuthorListMenuItem":
                    NavView.Header = "wybrano: " + args.InvokedItemContainer.Name;
                    docStrona = typeof(AuthorListMenuPage);
                    break;
                case "PublisherListMenuItem":
                    NavView.Header = "wybrano: " + args.InvokedItemContainer.Name;
                    docStrona = typeof(PublisherListMenuItem);
                    break;
                case "BookListMenuItem":
                    NavView.Header = "wybrano: " + args.InvokedItemContainer.Name;
                    docStrona = typeof(BookListMenuItem);
                    break;
                case "Help":
                    NavView.Header = "wybrano: " + args.InvokedItemContainer.Name;
                    docStrona = typeof(Help);
                    break;
                default:
                    break;
            }
            if (docStrona != null && docStrona != aktStrona)
            {
                frmMain.Navigate(docStrona);
            }
        }


        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            frmMain.GoBack();
        }
    }
}
