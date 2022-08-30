using System;
using System.Collections.Generic;
using System.Linq;
class Student
{
    private uint rokUrodzenia;
    private float[] dostepneOceny = {2, 3, 3.5f , 4, 4.5f, 5 };
    List<float> listaOcen;
    Student(string imie, string nazwisko, uint rokUrodzenia, float[] tablicaOcen)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        RokUrodzenia = rokUrodzenia;
        listaOcen = new List<float>(tablicaOcen);
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

    public void DodajOcene(float ocena)
    {
        if(!Array.Exists(dostepneOceny, element => element == ocena))
        {
            throw new ArgumentException(String.Format("Nieprawidlowa ocena!", ocena));
        }
        listaOcen.Add(ocena);
    }

    public void UsunOcene(int pozycja)
    {
        if(LiczbaOcen == 0)
        {
            throw new ArgumentException(String.Format("Brak ocen!", pozycja));
        }
        else if(pozycja > LiczbaOcen || pozycja < 0)
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
        if(LiczbaOcen == 0)
        {
            return "///////////////////////////////////////////////////////////////////////////////////" +
            "\nImie: " + Imie.ToString() +
            "\nNazwisko: " + Nazwisko.ToString() +
            "\nwiek: " + Wiek +
            "\nBrak ocen" +
            "\n///////////////////////////////////////////////////////////////////////////////////";
        }
        return "///////////////////////////////////////////////////////////////////////////////////" +
               "\nImie: " + Imie.ToString() +
               "\nNazwisko: " + Nazwisko.ToString() +
               "\nwiek: " + Wiek +
               "\nSrednia ocen: " + SredniaOcen() +
               "\nNajlepsza ocena: " + NajlepszaOcena() +
               "\nNajgorsza ocena: " + NajgorszaOcena() +
               "\n///////////////////////////////////////////////////////////////////////////////////";
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string imie, nazwisko;
            uint rokUrodzenia;
            float[] tablicaOcen = new float[0];
            Console.WriteLine("Podaj imie:");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj rok urodzenia:");
            rokUrodzenia = uint.Parse(Console.ReadLine());

            Student S1 = new Student(imie, nazwisko, rokUrodzenia, tablicaOcen);

            int wybor;
            do
            {
                Console.WriteLine("1 - dodaj ocene do listy.");
                Console.WriteLine("2 - usun ocene z listy.");
                Console.WriteLine("3 - wyswietl liste.");
                Console.WriteLine("4 - przejdz do podsumowania.");
                wybor = int.Parse(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        float ocena;
                        Console.WriteLine("Podaj ocene: ");
                        ocena = float.Parse(Console.ReadLine());
                        try
                        {
                            S1.DodajOcene(ocena);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        int pozycja;
                        Console.WriteLine("Podaj pozycje oceny na liscie: ");
                        pozycja = int.Parse(Console.ReadLine());
                        S1.UsunOcene(pozycja);
                        try
                        {
                            S1.UsunOcene(pozycja);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Oceny: " + S1.WyswietlOceny());
                        break;
                    case 4:

                        break;
                    default:

                        break;
                }
            } while (wybor != 4);

            Console.WriteLine(S1);
        }
    }
}

