using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using bibModelWitkowski.Model;
using Windows.Networking.Vpn;
using System.Xml.Serialization;
using bibModelWitkowski;
using Windows.UI.Xaml.Controls;
using System.IO;

namespace bibKliWitkowski
{
    public class BDLibraryUWP
    {
        readonly string authorsFIle, publishersFIle, booksFile;
        readonly StorageFolder pathUWP;

        public List<AutorzyAutor> AuthorsLst;
        public List<WydawnictwaWydawnictwo> PublishersLst;
        public List<KsiazkiKsiazka> BooksLst;

        public BDLibraryUWP(string authorsFile = DefaultFileNames.Authors, string publishersFIle = DefaultFileNames.Publishers, string booksFile = DefaultFileNames.Books, StorageFolder pathUWP = null)
        {
            this.authorsFIle = authorsFile;
            this.publishersFIle = publishersFIle;
            this.booksFile = booksFile;
            this.pathUWP = pathUWP;
            this.pathUWP = KnownFolders.DocumentsLibrary;
        }
        T Deserialize<T>(StorageFile file)
        {
            var xs = new XmlSerializer(typeof(T));
            try
            {
                using (Stream reader = file.OpenStreamForReadAsync().Result)
                {
                    return (T)xs.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async void TestData()
        {
            //bool jestOk = false;
            string kom = "";
            var itemAF = await pathUWP.TryGetItemAsync(authorsFIle);
            var itemPF = await pathUWP.TryGetItemAsync(publishersFIle);
            var itemBF = await pathUWP.TryGetItemAsync(booksFile);

            if (itemAF == null)
            {
                kom += $"{authorsFIle}, ";
            }
            if (itemPF == null)
            {
                kom += $"{publishersFIle}, ";
            }
            if (itemBF == null)
            {
                kom += $"{booksFile}, ";
            }

            if (kom != "")
            {
                //problem z danymi
                var dlg = new ContentDialog()
                {
                    Title = "Problem z plikami danych:",
                    Content = kom,
                    CloseButtonText = "OK",
                };
                await dlg.ShowAsync();
                App.Current.Exit();
                return;
            }
            var lst = Deserialize<Autorzy>(itemAF as StorageFile).Autor;
            AuthorsLst = (from item in lst
                          orderby item.nazwisko
                          select item).ToList();
            return;
        }

        async void Serializuj()
        {
            var aut = new Autorzy() { Autor = AuthorsLst.ToArray() };
            var xs = new XmlSerializer(typeof(Autorzy));
            StorageFile nowy = await pathUWP.CreateFileAsync(authorsFIle, CreationCollisionOption.ReplaceExisting);
            try
            {
                using (Stream writer = await nowy.OpenStreamForWriteAsync())
                {
                    xs.Serialize(writer, aut);
                }
            }
            catch (Exception ex)
            {
                var dlg = new ContentDialog()
                {
                    Title = ex.Message,
                    Content = ex,
                    CloseButtonText = "OK"
                };
                await dlg.ShowAsync();
            }
        }

        internal void Save()
        {
            Serializuj();
        }
    }
}
