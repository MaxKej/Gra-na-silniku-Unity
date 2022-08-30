using System;
using System.Collections.Generic;
using System.Linq;

public interface IOcenialny
{
    public void DodajOcene(float ocena);
    public void UsunOcene(int pozycja);
    public string WyswietlOceny();
    public float SredniaOcen();
    public float NajlepszaOcena();
    public float NajgorszaOcena();
}

class Osoba
{
    public uint rokUrodzenia;

    public Osoba(string imie, string nazwisko, uint rokUrodzenia)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        RokUrodzenia = rokUrodzenia;
    }

    public void DaneO(string imie, string nazwisko, uint rokUrodzenia)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        RokUrodzenia = rokUrodzenia;
    }

    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public uint RokUrodzenia
    {
        get => rokUrodzenia;
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
            {
                throw new ArgumentException(String.Format("Nieprawidlowy rok urodzenia!", value));
            }

            rokUrodzenia = value;

        }
    }

    public uint Wiek => (uint)DateTime.Now.Year - rokUrodzenia;

    public override string ToString()
    {
        return "///////////////////////////////////////////////////////////////////////////////////" +
            "\nImie: " + Imie.ToString() +
            "\nNazwisko: " + Nazwisko.ToString() +
            "\nwiek: " + Wiek;
    }
}
class Student : Osoba, IOcenialny
{
    private float[] dostepneOceny = { 2, 3, 3.5f, 4, 4.5f, 5 };
    List<float> listaOcen;

    Student(string imie, string nazwisko, uint rokUrodzenia, float[] tablicaOcen) : base(imie, nazwisko, rokUrodzenia)
    {
        listaOcen = new List<float>(tablicaOcen);
    }

    public void DodajOcene(float ocena)
    {
        if (!Array.Exists(dostepneOceny, element => element == ocena))
        {
            throw new ArgumentException(String.Format("Nieprawidlowa ocena!", ocena));
        }
        listaOcen.Add(ocena);
    }

    public void UsunOcene(int pozycja)
    {
        if (LiczbaOcen == 0)
        {
            throw new ArgumentException(String.Format("Brak ocen!", pozycja));
        }
        else if (pozycja > LiczbaOcen || pozycja < 0)
        {
            throw new ArgumentException(String.Format("Wyjscie poza zakres!", pozycja));
        }
        listaOcen.RemoveAt(pozycja - 1);
    }

    public string WyswietlOceny()
    {
        string oceny = string.Join(" ", listaOcen);
        return oceny;
    }
    public int LiczbaOcen => listaOcen.Count;

    public float SredniaOcen()
    {
        return listaOcen.Average();
    }

    public float NajlepszaOcena()
    {
        return listaOcen.Max();
    }

    public float NajgorszaOcena()
    {
        return listaOcen.Min();
    }

    public override string ToString()
    {

        if (LiczbaOcen == 0)
        {
            return base.ToString() +
                   "\nBrak ocen";
        }
        return base.ToString() +
               "\nSrednia ocen: " + SredniaOcen() +
               "\nNajlepsza ocena: " + NajlepszaOcena() +
               "\nNajgorsza ocena: " + NajgorszaOcena();
    }
    public static void Main(string[] args)
    {
        //string imie, nazwisko;
        //uint rokUrodzenia;
        //float[] tablicaOcen = new float[0];
        float[] tablicaOcen1 = { 3, 2, 3.5f, 4, 5 };
        float[] tablicaOcen2 = { 5, 2, 3, 4.5f, 5 };

        //Console.WriteLine("Podaj imie:");
        //imie = Console.ReadLine();
        //Console.WriteLine("Podaj nazwisko:");
        //nazwisko = Console.ReadLine();
        //Console.WriteLine("Podaj rok urodzenia:");
        //rokUrodzenia = uint.Parse(Console.ReadLine());

        Osoba o1 = new Osoba("Jan", "Kowalski", 1986);
        Osoba o2 = new Osoba("Adam", "Nowak", 1982);
        Student s1 = new Student("Radoslaw", "Warzecha", 2001, tablicaOcen1);
        Student s2 = new Student("Marek", "Koniecko", 1999, tablicaOcen2);

        List<Osoba> listaOsob = new List<Osoba>();

        listaOsob.Add(s1);
        listaOsob.Add(o1);
        listaOsob.Add(s2);
        listaOsob.Add(o1);

        for(int i = 0; i < listaOsob.Count; i++)
        {
            Console.WriteLine(listaOsob[i]);
        }

        //int wybor;
        //do
        //{
        //    Console.WriteLine("1 - dodaj ocene do listy.");
        //    Console.WriteLine("2 - usun ocene z listy.");
        //    Console.WriteLine("3 - wyswietl liste.");
        //    Console.WriteLine("4 - przejdz do podsumowania.");
        //    wybor = int.Parse(Console.ReadLine());
        //    switch (wybor)
        //    {
        //        case 1:
        //            float ocena;
        //            Console.WriteLine("Podaj ocene: ");
        //            ocena = float.Parse(Console.ReadLine());
        //            try
        //            {
        //                s1.DodajOcene(ocena);
        //            }
        //            catch (ArgumentException e)
        //            {
        //                Console.WriteLine(e.Message);
        //            }
        //            break;
        //        case 2:
        //            int pozycja;
        //            Console.WriteLine("Podaj pozycje oceny na liscie: ");
        //            pozycja = int.Parse(Console.ReadLine());
        //            s1.UsunOcene(pozycja);
        //            try
        //            {
        //                s1.UsunOcene(pozycja);
        //            }
        //            catch (ArgumentException e)
        //            {
        //                Console.WriteLine(e.Message);
        //            }
        //            break;
        //        case 3:
        //            Console.WriteLine("Oceny: " + s1.WyswietlOceny());
        //            break;
        //        case 4:

        //            break;
        //        default:

        //            break;
        //    }
        //} while (wybor != 4);

        //Console.WriteLine(s1);
    }
}

