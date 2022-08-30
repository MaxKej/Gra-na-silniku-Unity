using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generics2
{
    class Para<U, V>
    {
        public U Uwart { get; private set; }
        public V Vwart { get; private set; }
        public static Para<U, V>[] Paruj(ICollection<U> a, ICollection<V> b)
        {
            if (a.Count() != b.Count())    // dlatego potrzebujemy ICollection
                throw new ArgumentOutOfRangeException("argumenty funkcji Pruj nie maja tej samej ilosci elementow");

            Para<U, V>[] tab = new Para<U, V>[a.Count()];
            IEnumerator<U> aEnumerator = a.GetEnumerator();
            IEnumerator<V> bEnumerator = b.GetEnumerator();
            for (int i = 0; aEnumerator.MoveNext() && bEnumerator.MoveNext(); i++)
                tab[i] = new Para<U, V> { Uwart = aEnumerator.Current, Vwart = bEnumerator.Current };
            return tab;
        }
    }
    public interface IOcenialnych
    {
        public float sredniaOcen();
        public float najlepszaOcena();
        public float najgorszaOcena();
        public void dodajOcene(float ocena);
        public void ususnOcene(float ocena);
    }
    public class Dziennik<T> where T : IOcenialnych
    {
        List<T> dziennik;
        /*public Dodaj(T dod)
        {
            //trzeba dać jakiś warunek, by je doda
        }*/
    }
    internal class Program
    {
        public static Dictionary<char, int> Zlicz(string s)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!result.ContainsKey(s[i]))
                    result.Add(s[i], 0);
                else
                    result[s[i]]++;
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<int> a = new List<int>() { 1, 3, 5, 8 };
            List<int> b = new List<int>() { 2, 7, 9, 10 };
            ICollection<int> c = a;
            ICollection<int> d = b;
            Para<int, int>[] e = Para<int, int>.Paruj(c, d);
            for (int i = 0; i < a.Count; i++)
            {
                Console.Write(e[i].Uwart.ToString() + " " + e[i].Vwart.ToString() + " ");
                Console.WriteLine();
            }
        }
    }
}

