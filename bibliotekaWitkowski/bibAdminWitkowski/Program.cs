// See https://aka.ms/new-console-template for more information
using static System.Console;

var db = new bibModelWitkowski.BDLibrary(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\");


//Console.WriteLine("plik z autorami: {0}", db.authorsFile);
//Console.WriteLine("plik z wydawnictwami: {0}", db.publishersFile);
//Console.WriteLine("plik z ksiązkami: {0}", db.booksFile);

char menuOption = Menu(true);

switch (menuOption)
{
    case 'A':
        WriteLine("\n");
        ReadKey();
        Menu(true);
        break;
    case 'W':
        ReadKey();
        ShowData(db);
        ReadKey();
        Menu(true);
        break;
    case 'K':
        ReadKey();
        ShowBooks(db);
        ReadKey();
        Menu(true);
        ReadKey();
        break;
    case 'X':
        ReadKey();
        Menu(true);
        break;
    default:
        Menu(false);
        ReadKey();
        break;
} while (menuOption != 'X') ;


static void ShowData(bibModelWitkowski.BDLibrary db)
{
    string dane = db.ReportData();
    WriteLine("\n\n{0}", dane);

    WriteLine("\n==========WERSJA II===========\n");

    var authors = db.ReportData2();
    string frm = "{0,4}| {1,-15}| {2,-10}| {3,8}";
    string head = string.Format(frm, "Id", "nazwisko", "imię", "rok ur.");
    string kreska = new string('-', head.Length);

    WriteLine(head + "\n" + kreska);

    foreach (var item in authors.Autor)
    {
        WriteLine(frm, item.id, item.nazwisko, item.imie, item.rokUr);
    }

    WriteLine(kreska);

    WriteLine("\n==========WERSJA III===========\n");

    var authorsSort = db.ReportDataLQ();
    if (authorsSort != null)
    {
        WriteLine(head + "\n" + kreska);
        foreach (var item in authorsSort)
        {
            WriteLine(frm, item.id, item.nazwisko, item.imie, item.rokUr);
        }
    }
    else
    {
        WriteLine("### Brak Danych ###");
    }
    WriteLine(kreska);

    WriteLine("\n==========WERSJA IV===========\n");
    var booksSort = db.ReportDataLQ2();
    if (booksSort != null)
    {
        string frmBooks = "{0,4}| {1,-25}| {2,-20}| {3,-15}| {4,8}";
        string headBooks = string.Format(frmBooks, "Id", "Tytuł", "Autor", "Wydawnictwo", "Cena");
        string kreskaBooks = new string('-', headBooks.Length);

        WriteLine(headBooks);
        WriteLine(kreskaBooks);

        foreach (var book in booksSort)
        {
            WriteLine(frmBooks, book.id, book.tytul, book.NazwiskoImie, book.NazwaWydawnictwa, book.cena);
        }

        WriteLine(kreskaBooks);
    }
    else
    {
        WriteLine("### Brak Danych ###");
    }
}

static void ShowBooks(bibModelWitkowski.BDLibrary db)
{
    var booksSort = db.ReportDataLQ2();
    if (booksSort != null && booksSort.Count > 0)
    {
        string frmBooks = "{0,4}| {1,-25}| {2,-20}| {3,-15}| {4,8}";
        string headBooks = string.Format(frmBooks, "Id", "Tytuł", "Autor", "Wydawnictwo", "Cena");
        string kreskaBooks = new string('-', headBooks.Length);

        WriteLine("\n========== LISTA KSIĄŻEK ==========\n");
        WriteLine(headBooks);
        WriteLine(kreskaBooks);

        foreach (var book in booksSort)
        {
            WriteLine(frmBooks, book.id, book.tytul, book.NazwiskoImie, book.NazwaWydawnictwa, book.cena);
        }

        WriteLine(kreskaBooks);
    }
    else
    {
        WriteLine("### Brak Danych ###");
    }
}


static char Menu(bool opt)
{
    if (opt)
    {

        char option;
        Clear();
        WriteLine("Supersoft Company Ltd");
        WriteLine("Biblioteka 2025");

        WriteLine("--------------------");

        WriteLine("Wybierz opcję: ");
        WriteLine("W - Wyświetl dane - wszystkie");
        WriteLine("A - dane autora");
        WriteLine("K - Książki(nazwiska i nazwy wydawnictw)");
        WriteLine("\nX - Wyjdź");
        Write("Twój wybór: ");

        option = char.ToUpper(ReadKey().KeyChar);
        WriteLine();
        return option;
    }
    else
    {
        WriteLine("\nBrak takiej opcji - wybierz właściwą");
        return ' ';
    }
}





