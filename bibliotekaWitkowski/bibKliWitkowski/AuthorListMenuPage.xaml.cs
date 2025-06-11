using bibModelWitkowski.Model;
using System;
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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace bibKliWitkowski
{
    //pomocnicza do danych

    class DataGridDataSourceAuthors
    {
        public List<AutorzyAutor> Autorzy = new List<AutorzyAutor>();
    }

    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class AuthorListMenuPage : Page
    {
        DataGridDataSourceAuthors AuthorsViewModel;
        BDLibraryUWP dbUWP;
        public AuthorListMenuPage()
        {
            dbUWP = (App.Current as App).db;
            AuthorsViewModel = new DataGridDataSourceAuthors()
            {
                Autorzy = dbUWP.AuthorsLst
            };
            this.InitializeComponent();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var x = AuthorsViewModel.Autorzy;
            dbUWP.Save();
            base.OnNavigatedFrom(e);
        }
    }
}

