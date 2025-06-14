using bibModelWitkowski.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace bibKliWitkowski
{
    public class DataGridDataSourceAuthors
    {
        public ObservableCollection<AutorzyAutor> Autorzy { get; set; } = new ObservableCollection<AutorzyAutor>();
    }

    public sealed partial class AuthorListMenuPage : Page
    {
        public DataGridDataSourceAuthors AuthorsViewModel { get; set; }
        BDLibraryUWP dbUWP;

        public AuthorListMenuPage()
        {
            dbUWP = (App.Current as App).db;

            AuthorsViewModel = new DataGridDataSourceAuthors()
            {
                Autorzy = new ObservableCollection<AutorzyAutor>(dbUWP.AuthorsLst)
            };

            this.InitializeComponent();
            this.DataContext = this; // umożliwia powiązanie XAML z AuthorsViewModel
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            dbUWP.AuthorsLst = AuthorsViewModel.Autorzy.ToList(); // zapis zmian
            dbUWP.Save();
            base.OnNavigatedFrom(e);
        }

        private void DodajAutora_Click(object sender, RoutedEventArgs e)
        {
            var nowyAutor = new AutorzyAutor() { imie = "Nowy", nazwisko = "Autor" }; // przykładowe dane
            AuthorsViewModel.Autorzy.Add(nowyAutor);
        }

        private void UsunAutora_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsDataGrid.SelectedItem is AutorzyAutor zaznaczonyAutor)
            {
                AuthorsViewModel.Autorzy.Remove(zaznaczonyAutor);
            }
        }
    }
}
