using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using bibModelWitkowski.Model;
using Windows.UI.Xaml.Controls;
using System.IO;
using System.Xml.Serialization;
using bibModelWitkowski;

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
            this.pathUWP = pathUWP ?? KnownFolders.DocumentsLibrary;
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
            string kom = "";
            var itemAF = await pathUWP.TryGetItemAsync(authorsFIle);
            var itemPF = await pathUWP.TryGetItemAsync(publishersFIle);
            var itemBF = await pathUWP.TryGetItemAsync(booksFile);

            if (itemAF == null) kom += $"{authorsFIle}, ";
            if (itemPF == null) kom += $"{publishersFIle}, ";
            if (itemBF == null) kom += $"{booksFile}, ";

            if (kom != "")
            {
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

            var lstA = Deserialize<Autorzy>(itemAF as StorageFile)?.Autor;
            AuthorsLst = lstA?.OrderBy(x => x.nazwisko).ToList() ?? new List<AutorzyAutor>();

            var lstP = Deserialize<Wydawnictwa>(itemPF as StorageFile)?.Wydawnictwo;
            PublishersLst = lstP?.OrderBy(x => x.nazwa).ToList() ?? new List<WydawnictwaWydawnictwo>();

            var lstB = Deserialize<Ksiazki>(itemBF as StorageFile)?.Ksiazka;
            BooksLst = lstB?.OrderBy(x => x.tytul).ToList() ?? new List<KsiazkiKsiazka>();
        }

        async void Serializuj()
        {
            try
            {
                var aut = new Autorzy() { Autor = AuthorsLst.ToArray() };
                var xsAut = new XmlSerializer(typeof(Autorzy));
                StorageFile nowyAut = await pathUWP.CreateFileAsync(authorsFIle, CreationCollisionOption.ReplaceExisting);
                using (Stream writer = await nowyAut.OpenStreamForWriteAsync())
                {
                    xsAut.Serialize(writer, aut);
                }

                var wyd = new Wydawnictwa() { Wydawnictwo = PublishersLst.ToArray() };
                var xsWyd = new XmlSerializer(typeof(Wydawnictwa));
                StorageFile nowyWyd = await pathUWP.CreateFileAsync(publishersFIle, CreationCollisionOption.ReplaceExisting);
                using (Stream writer = await nowyWyd.OpenStreamForWriteAsync())
                {
                    xsWyd.Serialize(writer, wyd);
                }

                var ks = new Ksiazki() { Ksiazka = BooksLst.ToArray() };
                var xsKs = new XmlSerializer(typeof(Ksiazki));
                StorageFile nowyKs = await pathUWP.CreateFileAsync(booksFile, CreationCollisionOption.ReplaceExisting);
                using (Stream writer = await nowyKs.OpenStreamForWriteAsync())
                {
                    xsKs.Serialize(writer, ks);
                }
            }
            catch (Exception ex)
            {
                var dlg = new ContentDialog()
                {
                    Title = ex.Message,
                    Content = ex.ToString(),
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