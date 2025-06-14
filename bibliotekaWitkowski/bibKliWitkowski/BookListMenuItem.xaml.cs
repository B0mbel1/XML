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

namespace bibKliWitkowski
{
    public class DataGridDataSourceBooks
    {
        public ObservableCollection<KsiazkiKsiazka> Ksiazki { get; set; } = new ObservableCollection<KsiazkiKsiazka>();
    }

    public sealed partial class BookListMenuItem : Page
    {
        public DataGridDataSourceBooks BooksViewModel { get; set; }
        BDLibraryUWP dbUWP;

        public BookListMenuItem()
        {
            this.InitializeComponent();

            dbUWP = (App.Current as App).db;

            //var listaKsiazek = dbUWP.BooksLst ?? new List<KsiazkiKsiazka>();

            BooksViewModel = new DataGridDataSourceBooks()
            {
                Ksiazki = new ObservableCollection<KsiazkiKsiazka>(dbUWP.BooksLst)
            };

            this.DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            dbUWP.BooksLst = BooksViewModel.Ksiazki.ToList();
            dbUWP.Save();
            base.OnNavigatedFrom(e);
        }

        private void DodajKsiazke_Click(object sender, RoutedEventArgs e)
        {
            var nowaKsiazka = new KsiazkiKsiazka() { id = 0, tytul = "Nowa", IdAutora = 0, IdWydawcy = 0, rok_wydania = 0, cena = 0, ISBN = 0 }; // przykładowe dane
            BooksViewModel.Ksiazki.Add(nowaKsiazka);
        }

        private void UsunKsiazke_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is KsiazkiKsiazka zaznaczonaKsiazka)
            {
                BooksViewModel.Ksiazki.Remove(zaznaczonaKsiazka);
            }
        }
    }
}

