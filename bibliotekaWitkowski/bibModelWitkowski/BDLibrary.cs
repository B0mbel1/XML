using bibModelWitkowski.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;

namespace bibModelWitkowski
{
    public class BDLibrary
    {
        public readonly string authorsFile, publishersFile, booksFile;
        public BDLibrary(string path, string authorsFile = DefaultFileNames.Authors, string publishersFile = DefaultFileNames.Publishers, string booksFile = DefaultFileNames.Books)
        {
            this.authorsFile = path + authorsFile;
            this.publishersFile = path + publishersFile;
            this.booksFile = path + booksFile;
        }

        public bool TestData()
        {
            var authors = new bibModelWitkowski.Model.Autorzy();
            authors.Autor = new bibModelWitkowski.Model.AutorzyAutor[]
            {
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 1,
                    nazwisko = "Prus",
                    imie = "Bolesław",
                    rokUr = 1847
                },
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 2,
                    nazwisko = "Wyspiański",
                    imie = "Stanisław",
                    rokUr = 1869
                },
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 3,
                    nazwisko = "Herling-Grudziński",
                    imie = "Gustaw",
                    rokUr = 1919
                },
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 4,
                    nazwisko = "Lem",
                    imie = "Stanisław",
                    rokUr = 1921
                },
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 5,
                    nazwisko = "Kapuściński",
                    imie = "Ryszard",
                    rokUr = 1932
                },
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 6,
                    nazwisko = "Reymont",
                    imie = "Władysław",
                    rokUr = 1867
                },
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 7,
                    nazwisko = "Sienkiewicz",
                    imie = "henryk",
                    rokUr = 1846
                },
                new bibModelWitkowski.Model.AutorzyAutor()
                {
                    id = 8,
                    nazwisko = "Witkowski",
                    imie = "Jakub",
                    rokUr = 2001
                }
            };

            //Wydawnictwo
            var publishers = new bibModelWitkowski.Model.Wydawnictwa();
            publishers.Wydawnictwo = new bibModelWitkowski.Model.WydawnictwaWydawnictwo[]
            {
                new bibModelWitkowski.Model.WydawnictwaWydawnictwo()
                {
                    id = 1,
                    nazwa = "Dom Wydawniczy Rebis",
                    strona = "https://www.rebis.com.pl",
                },
                new bibModelWitkowski.Model.WydawnictwaWydawnictwo()
                {
                    id = 2,
                    nazwa = "Wydawnictwo Albatros",
                    strona = "https://wydawnictwoalbatros.com",
                },
                new bibModelWitkowski.Model.WydawnictwaWydawnictwo()
                {
                    id = 3,
                    nazwa = "Wydawnictwo Czarne",
                    strona = "http://czarne.com.pl  ",
                },
                new bibModelWitkowski.Model.WydawnictwaWydawnictwo()
                {
                    id = 4,
                    nazwa = "Wydawnictwo Literackie ",
                    strona = "http://wydawnictwoliterackie.pl",
                },
                new bibModelWitkowski.Model.WydawnictwaWydawnictwo()
                {
                    id = 5,
                    nazwa = "Fabryka Słów",
                    strona = "https://fabrykaslow.com.pl",
                },
            };

            ////Książki
            //var doc = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "no"),
            //    new XComment("Przykładowe dane-książki.xml"),
            //    new XElement("Książki",
            //        new XAttribute("wersja", "2.0"),
            //        new XElement("ksiazka",
            //            new XAttribute("id", "1"),
            //            new XAttribute("IdAutora", "1"),
            //            new XAttribute("tytul", "Lalka"),
            //            new XAttribute("rok_wydania", "2010"),
            //            new XAttribute("IdWydawcy", "1")
            //            )
            //        )
            //);
            //doc.Save(booksFile);

            //Ksiązka
            var books = new bibModelWitkowski.Model.Ksiazki();
            books.Ksiazka = new bibModelWitkowski.Model.KsiazkiKsiazka[]
            {
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 1,
                    IdAutora = 1,
                    tytul = "Lalka",
                    rok_wydania = 2010,
                    IdWydawcy = 1,
                    cena = 20.99,
                    ISBN =  9781858660653,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 2,
                    IdAutora = 2,
                    tytul = "Wesele",
                    rok_wydania = 2011,
                    IdWydawcy = 1,
                    cena = 25.00,
                    ISBN =  9788304010468,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 3,
                    IdAutora = 1,
                    tytul = "Placówka",
                    rok_wydania = 2012,
                    IdWydawcy = 2,
                    cena = 25.00,
                    ISBN =  9788360322307,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 4,
                    IdAutora = 3,
                    tytul = "Inny świat",
                    rok_wydania = 2009,
                    IdWydawcy = 2,
                    cena = 30.99,
                    ISBN =  9780192819390,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 5,
                    IdAutora = 4,
                    tytul = "Powrót z gwiazd",
                    rok_wydania = 2013,
                    IdWydawcy = 2,
                    cena = 34.99,
                    ISBN =  9780151770823,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 6,
                    IdAutora = 5,
                    tytul = "Heban",
                    rok_wydania = 2014,
                    IdWydawcy = 3,
                    cena = 31.50,
                    ISBN = 9780679779070,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 7,
                    IdAutora = 1,
                    tytul = "Faraon",
                    rok_wydania = 2008,
                    IdWydawcy = 3,
                    cena = 51.99,
                    ISBN = 9783746610306,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 8,
                    IdAutora = 6,
                    tytul = "Ziemia Obiecana",
                    rok_wydania = 2001,
                    IdWydawcy = 4,
                    cena = 19.99,
                    ISBN = 9781784350888,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 9,
                    IdAutora = 7,
                    tytul = "Ogniem i Mieczem",
                    rok_wydania = 2000,
                    IdWydawcy = 4,
                    cena = 40.00,
                    ISBN = 9788366257481,
                },
                new bibModelWitkowski.Model.KsiazkiKsiazka()
                {
                    id = 10,
                    IdAutora = 8,
                    tytul = "Dzieła dud",
                    rok_wydania = 2025,
                    IdWydawcy = 5,
                    cena = 100.00,
                    ISBN = 9977882345123,
                },
            };


            bool sukcesAuthors = true;
            bool sukcesBooks = true;
            bool sukcesPublishers = true;

            if (!File.Exists(authorsFile))
            {
                sukcesAuthors = SerializujDane(authors, authorsFile);
            }
            if (!File.Exists(booksFile))
            {
                sukcesBooks = SerializujDane(books, booksFile);
            }
            if (!File.Exists(publishersFile))
            {
                sukcesPublishers = SerializujDane(publishers, publishersFile);
            }
            if (sukcesAuthors && sukcesBooks && sukcesPublishers)
            {
                return true;
            }
            return false;
        }

        private bool SerializujDane<T>(T data, string fileName)
        {
            var xs = new XmlSerializer(typeof(T));
            bool sukces = false;
            try
            {
                using (StreamWriter s = new StreamWriter(fileName))
                {
                    xs.Serialize(s, data);
                }
                sukces = true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sukces;
        }
        private T DeserializujDane<T>(string fileName) where T : class
        {
            if (!File.Exists(fileName)) return null;
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public string ReportData()
        {
            string wynik = XDocument.Load(authorsFile).ToString();
            return wynik;
        }

        public Autorzy ReportData2()
        {
            var xs = new XmlSerializer(typeof(Autorzy));
            var s = new StreamReader(authorsFile);
            var authors = xs.Deserialize(s) as Autorzy;

            return authors;
        }

        public IOrderedEnumerable<AutorzyAutor> ReportDataLQ()
        {
            var xs = new XmlSerializer(typeof(Autorzy));
            var s = new StreamReader(authorsFile);
            var sortListAuthors = from item in ReportData2().Autor
                                  orderby item.nazwisko
                                  select item;

            return sortListAuthors;
        }
        public List<AutorzyAutor> GetOrderedAuthors()
        {
            var authors = DeserializujDane<Autorzy>(authorsFile)?.Autor ?? Array.Empty<AutorzyAutor>();
            return authors.OrderBy(a => a.nazwisko).ToList(); 
        }

        public List<WydawnictwaWydawnictwo> GetOrderedPublishers()
        {
            var publishers = DeserializujDane<Wydawnictwa>(publishersFile)?.Wydawnictwo ?? Array.Empty<WydawnictwaWydawnictwo>();
            return publishers.OrderBy(p => p.nazwa).ToList();
        }


        public List<KsiazkiKsiazkaExt> ReportDataLQ2()
        {
            var books = DeserializujDane<Ksiazki>(booksFile)?.Ksiazka ?? Array.Empty<KsiazkiKsiazka>();
            var authors = GetOrderedAuthors(); 
            var publishers = GetOrderedPublishers();

            var sortListAuthors = ReportDataLQ().ToList();

            var sortLst = (from book in books
                           join author in authors on book.IdAutora equals author.id
                           join pub in publishers on book.IdWydawcy equals pub.id
                           orderby book.tytul
                           select new KsiazkiKsiazkaExt()
                           {
                               id = book.id,
                               tytul = book.tytul,
                               cena = book.cena,
                               NazwiskoImie = author.nazwisko + " " + author.imie,
                               NazwaWydawnictwa = pub.nazwa
                           }).ToList();

            return sortLst.ToList();
        }

    }
}
