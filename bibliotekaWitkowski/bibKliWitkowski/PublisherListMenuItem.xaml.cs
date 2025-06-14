using bibModelWitkowski.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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
            if (PublishersDataGrid.SelectedItem is WydawnictwaWydawnictwo zaznaczone)
            {
                PublishersViewModel.Wydawnictwa.Remove(zaznaczone);
            }
        }
    }
}

