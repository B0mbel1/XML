using bibModelWitkowski.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace bibKliWitkowski
{
    public class DataGridDataSourcePublishers
    {
        public ObservableCollection<WydawnictwaWydawnictwo> Wydawnictwa { get; set; } = new ObservableCollection<WydawnictwaWydawnictwo>();
    }

    public sealed partial class PublisherListMenuItem : Page
    {
        public DataGridDataSourcePublishers PublishersViewModel { get; set; }
        BDLibraryUWP dbUWP;
        public PublisherListMenuItem()
        {
            this.InitializeComponent();
            dbUWP = (App.Current as App).db;

            PublishersViewModel = new DataGridDataSourcePublishers()
            {
                Wydawnictwa = new ObservableCollection<WydawnictwaWydawnictwo>(dbUWP.PublishersLst)
            };

            this.DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            dbUWP.PublishersLst = PublishersViewModel.Wydawnictwa.ToList();
            dbUWP.Save();
            base.OnNavigatedFrom(e);
        }
        private void DodajWydawnictwo_Click(object sender, RoutedEventArgs e)
        {
            var noweWydawnictwo = new WydawnictwaWydawnictwo() { id = 0, nazwa = "Nazwa", strona = "Strona" };
            PublishersViewModel.Wydawnictwa.Add(noweWydawnictwo);
        }
        private void UsunWydawnictwo_Click(object sender, RoutedEventArgs e)
        {
            if (PublishersDataGrid.SelectedItem is WydawnictwaWydawnictwo zaznaczoneWydawnictwo)
            {
                PublishersViewModel.Wydawnictwa.Remove(zaznaczoneWydawnictwo);
            }
        }


    }
}
