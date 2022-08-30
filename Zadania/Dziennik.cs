using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics2
{
    internal class Dziennik<T> where T : class, IOcenialny
    {
        public List<T> students = new List<T>();
        public void Dodaj(T student)
        {
            students.Add(student);
        }
        public void Usun(int pozycja)
        {
            students.RemoveAt(pozycja);
        }
        public void Wyczysc()
        {
            students.Clear();
        }
        public static KeyValuePair<Student, float> NajlepszaSrednia(Dictionary<Student, float>  listaSrednich)
        {
            Dictionary<Student, float> najlepsza = new Dictionary<Student, float>();
           
            float best = 0;
            foreach (Student student in listaSrednich.Keys)
            {
                if(best < student.SredniaOcen())
                {
                    best = student.SredniaOcen();
                }
            }

            foreach (Student student in listaSrednich.Keys)
            {
                if (best == student.SredniaOcen())
                {
                    Student najlepszy = student;
                    return new KeyValuePair<Student, float>(najlepszy, best);
                }
            }
            return new KeyValuePair<Student, float>(null, best);
        }
        public static Dictionary<Student, float> WszystkieSrednie(Dziennik<Student> dziennik)
        {
            Dictionary<Student, float> lista = new Dictionary<Student, float>();

            for(int i = 0; i < dziennik.students.Count(); i++)
            {
                lista.Add(dziennik.students[i], dziennik.students[i].SredniaOcen());
            }
            return lista;
        }
        public static void Main(string[] args)
        {
        }
    }
    public interface IOcenialny
    {
        public void DodajOcene(float ocena);
        public void UsunOcene(int pozycja);
        public string WyswietlOceny();
        public float SredniaOcen();
        public float NajlepszaOcena();
        public float NajgorszaOcena();
    }

    public class Student : IOcenialny
    {
        private uint rokUrodzenia;
        private float[] dostepneOceny = { 2, 3, 3.5f, 4, 4.5f, 5 };
        List<float> listaOcen;
        public Student(string imie, string nazwisko, uint rokUrodzenia, float[] tablicaOcen)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            RokUrodzenia = rokUrodzenia;
            listaOcen = new List<float>(tablicaOcen);
        }

        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
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
            return
                "\nImie: " + Imie.ToString() +
                "\nNazwisko: " + Nazwisko.ToString() +
                "\nwiek: " + Wiek;
        }

        public static void Main(string[] args)
        {
            Dziennik<Student> dziennik = new Dziennik<Student>();
            float[] tablicaOcen1 = { 3, 2, 3.5f, 4, 5 };
            float[] tablicaOcen2 = { 5, 2, 3, 4.5f, 5 };
            float[] tablicaOcen3 = { 3, 2, 3.5f, 4, 5, 5, 5 };
            float[] tablicaOcen4 = { 3.5f, 2, 3, 4.5f, 5, 3 };

            Student s1 = new Student("Jan", "Kowalski", 1998, tablicaOcen1);
            Student s2 = new Student("Adam", "Nowak", 2000, tablicaOcen2);
            Student s3 = new Student("Radoslaw", "Warzecha", 2001, tablicaOcen3);
            Student s4 = new Student("Marek", "Koniecko", 1999, tablicaOcen4);

            dziennik.Dodaj(s1);
            dziennik.Dodaj(s2);
            dziennik.Dodaj(s3);
            dziennik.Dodaj(s4);

            //for (int i = 0; i < dziennik.students.Count; i++)
            //{
            //    Console.WriteLine(dziennik.students[i]);
            //}

            Dictionary<Student, float> listaSrednich = Dziennik<Student>.WszystkieSrednie(dziennik);
            foreach (KeyValuePair<Student, float> para in listaSrednich)
            {
                Console.Write("{0}\nŚrednia ocen: {1}" + "\n", para.Key, para.Value);
            }

            Console.Write("\nNajlepszy student:");
            KeyValuePair<Student, float> najlepszaSrednia = Dziennik<Student>.NajlepszaSrednia(listaSrednich);
            Console.Write("{0}\nŚrednia ocen: {1}" + "\n", najlepszaSrednia.Key, najlepszaSrednia.Value);
        }

    }
}
