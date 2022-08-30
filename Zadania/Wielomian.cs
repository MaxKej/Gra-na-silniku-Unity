using System;
using System.Collections.Generic;
using System.Linq;

namespace Wielomian
{
    class Wielomian : ICloneable
    {
        private float[] wspolczynniki;
        public Wielomian(float[] wspolczynniki)
        {
            Wspolczynniki = wspolczynniki;
        }

        public Wielomian(Wielomian w)
        {
            Wspolczynniki = w.wspolczynniki;
        }

        public object Clone()
        {
            //return (Wielomian)MemberwiseClone();
            return new Wielomian(Wspolczynniki);
        }

        public float[] Wspolczynniki 
        {
            get => (float[])wspolczynniki.Clone();
            set
            {
                wspolczynniki = new float[value.Length];
                value.CopyTo(wspolczynniki, 0);
            }
        }
        public int Stopien => wspolczynniki.Length - 1;

        //public float this[float index] => FindIndex(index);

        //private float FindIndex(float index)
        //{
        //    for (int i = 0; i < Wspolczynniki.Length; i++)
        //    {
        //        if (Wspolczynniki.Length - i - 1 == index)
        //        {
        //            return Wspolczynniki[i];
        //        }
        //    }

        //   throw new ArgumentOutOfRangeException(nameof(index),$"Nie ma wspolczynnika o numerze: {index} ");
        //}

        public float this[int index]
        {
            get
            {
                if (index > wspolczynniki.Length || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Nie ma wspolczynnika o numerze: {index} ");
                }
                return wspolczynniki[index];
            }
            set
            {
                if (index > wspolczynniki.Length || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Nie ma wspolczynnika o numerze: {index} ");
                }
                wspolczynniki[index] = value;
            }
        }

        public static Wielomian operator +(Wielomian w1, Wielomian w2)
        {
            float[] sumy;
            int dluzszy, krotszy, roznica;

            if (w1.Stopien >= w2.Stopien)
            {
                sumy = new float[w1.Stopien + 1];
                dluzszy = w1.Stopien;
                krotszy = w2.Stopien;
                roznica = dluzszy - krotszy;
                for (int i = 0; i <= dluzszy; i++)
                {
                    if (dluzszy - i <= krotszy)
                    {
                        sumy[i] = w1.wspolczynniki[i] + w2.wspolczynniki[i - roznica];
                    }
                    else
                    {
                        sumy[i] = w1.wspolczynniki[i];
                    }
                }
            }
            else
            {
                sumy = new float[w2.Stopien + 1];
                dluzszy = w2.Stopien;
                krotszy = w1.Stopien;
                roznica = dluzszy - krotszy;
                for (int i = 0; i <= dluzszy; i++)
                {
                    if (dluzszy - i <= krotszy)
                    {
                        sumy[i] = w1.wspolczynniki[i - roznica] + w2.wspolczynniki[i];
                    }
                    else
                    {
                        sumy[i] = w2.wspolczynniki[i];
                    }
                }
            }
            return new Wielomian(sumy);
        }

        public static Wielomian operator -(Wielomian w1, Wielomian w2)
        {
            float[] sumy;
            int dluzszy, krotszy, roznica;

            if (w1.Stopien >= w2.Stopien)
            {
                sumy = new float[w1.Stopien + 1];
                dluzszy = w1.Stopien;
                krotszy = w2.Stopien;
                roznica = dluzszy - krotszy;
                for (int i = 0; i <= dluzszy; i++)
                {
                    if (dluzszy - i <= w2.Stopien)
                    {
                        sumy[i] = w1.wspolczynniki[i] - w2.wspolczynniki[i - roznica];
                    }
                    else
                    {
                        sumy[i] = w1.wspolczynniki[i];
                    }
                }
            }
            else
            {
                sumy = new float[w2.Stopien + 1];
                dluzszy = w2.Stopien;
                krotszy = w1.Stopien;
                roznica = dluzszy - krotszy;
                for (int i = 0; i <= dluzszy; i++)
                {
                    if (dluzszy - i <= w1.Stopien)
                    {
                        sumy[i] = w1.wspolczynniki[i - roznica] - w2.wspolczynniki[i];
                    }
                    else
                    {
                        sumy[i] = -w2.wspolczynniki[i];
                    }
                }
            }
            return new Wielomian(sumy);
        }

        float Wartosc(float x)
        {
            float wartosc = 0;
            for(int i = 0; i < Stopien + 1; i++)
            {
                wartosc += (float)Math.Pow(x, i) * wspolczynniki[i];
            }

            return wartosc;
        }

        //public static double[] ToDouble(Wielomian w)
        //{
        //    if (w.Wspolczynniki == null)
        //        return null;

        //    double[] output = new double[w.Wspolczynniki.Length];
        //    for (int i = 0; i < w.Wspolczynniki.Length; i++)
        //        output[i] = w.Wspolczynniki[i];

        //    return output;
        //}

        public static explicit operator double[](Wielomian w) => Array.ConvertAll(w.wspolczynniki, x => (double)x);
        public static explicit operator float[](Wielomian w) => w.Wspolczynniki;

        public string ZapisWielomianu()
        {
            return string.Join(" + ", wspolczynniki.Select((x, i) => $"{x}x^{Stopien - i}"));
        }

        public override string ToString()
        {
            return "W(x)=" + ZapisWielomianu();
        }

        static void Main(string[] args)
        {
            float[] wspolczynniki1 = new float[5] {1, 2, 3, 4.5f, 5};
            float[] wspolczynniki2 = new float[6] {5, 1, 2.5f, 3.7f, 4.5f, 5};
            Wielomian w1 = new Wielomian(wspolczynniki1);
            Wielomian w2 = new Wielomian(wspolczynniki2);
            Console.WriteLine(w1);
            Console.WriteLine(w2);
            Wielomian w3 = w1 + w2;
            Console.WriteLine(w3);
            Wielomian w4 = w1 - w2;
            Console.WriteLine(w4);
            Console.WriteLine("W(3) = " + w1.Wartosc(3));
            Console.WriteLine(w2);
            try
            {
                Console.WriteLine("wartosc wspolczynnika przy x^3 dla w2 to " + w2[3]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            Wielomian w5 = new Wielomian(w1);
            Wielomian w6 = (Wielomian)w2.Clone();
            Console.WriteLine(w5);
            Console.WriteLine(w6);
            Console.WriteLine(String.Join(" ", (double[])w1));
        }
    }
}
