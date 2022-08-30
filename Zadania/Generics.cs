using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    class Generics
    {
        public static string Porownaj<T>(T a, T b) where T : IComparable<T>
        {
            int p = a.CompareTo(b);
            if (p == 0) return $"{a} = {b}";
            else if (p < 0) return $"{a} < {b}";
            else return $"{a} > {b}";
        }
        public static List<T> NaPrzemian<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            List<T> result = new List<T>();

            IEnumerator<T> aNext = a.GetEnumerator();
            IEnumerator<T> bNext = b.GetEnumerator();

            bool aNextExist = aNext.MoveNext();
            bool bNextExist = bNext.MoveNext();


            while (aNextExist || bNextExist)
            {
                if (aNextExist)
                {
                    result.Add(aNext.Current);
                    aNextExist = aNext.MoveNext();
                }

                if (bNextExist)
                {
                    result.Add(bNext.Current);
                    bNextExist = bNext.MoveNext();
                }

            }
            return result;
        }
        static void Main(string[] args)
        {
            List<int> a = new List<int>() {1, 3, 5, 8};
            List<int> b = new List<int>() {2, 7, 9, 10, 11, 13};

            List<int> c = NaPrzemian(a, b);

            for (int i = 0; i < c.Count; i++)
                Console.Write(c[i] + " ");

            int l1 = 1, l2 = 2;
            Console.WriteLine();
            Console.WriteLine(Porownaj(l1, l2));

        }
    }
}
