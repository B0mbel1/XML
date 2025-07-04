﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace bibKliWitkowski
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("tryb", out object savedValue))
            {
                if (savedValue is int themeValue)
                {
                    var savedTheme = (ElementTheme)themeValue;

                    switch (savedTheme)
                    {
                        case ElementTheme.Light:
                            LightRadioButton.IsChecked = true;
                            break;
                        case ElementTheme.Dark:
                            DarkRadioButton.IsChecked = true;
                            break;
                        default:
                            DefaultRadioButton.IsChecked = true;
                            break;
                    }
                }
            }
            else
            {
                DefaultRadioButton.IsChecked = true;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is FrameworkElement rootElement)
                rootElement.RequestedTheme = ElementTheme.Light;
            ApplicationData.Current.LocalSettings.Values["tryb"] = (int)ElementTheme.Light;

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is FrameworkElement rootElement)
                rootElement.RequestedTheme = ElementTheme.Dark;
            ApplicationData.Current.LocalSettings.Values["tryb"] = (int)ElementTheme.Dark;

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is FrameworkElement rootElement)
            {
                rootElement.RequestedTheme = ElementTheme.Default;
                ApplicationData.Current.LocalSettings.Values["tryb"] = (int)ElementTheme.Default;
            }

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.GoBack();
        //}
    }
}
