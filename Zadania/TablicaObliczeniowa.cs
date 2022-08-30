using System;
namespace Delegaty
{
    class TablicaObliczeniowa
    {
        int[] listaArgumentow;
        public TablicaObliczeniowa(params int[] listaArgumentow)
        {
            ListaArgumentow = listaArgumentow;
        }
        public int[] ListaArgumentow
        {
            get => (int[])listaArgumentow.Clone();
            set
            {
                listaArgumentow = new int[value.Length];
                value.CopyTo(listaArgumentow, 0);
            }
        }

        public delegate void AutoOperacja(ref int x);

        public int Oblicz(Func<int, int, int> sumaTablicy)
        {
            int result = ListaArgumentow[0];
            for(int i = 1; i < ListaArgumentow.Length; i++)
                result = sumaTablicy(result, ListaArgumentow[i]);
            return result;
        }

        //public void Aplikuj(params Func<int,int>[] ops)
        //{
        //    foreach(Func<int, int> op in ops)
        //    for (int i = 0; i < ListaArgumentow.Length; i++)
        //        listaArgumentow[i] = op(ListaArgumentow[i]);
        //}

        public void Aplikuj(params AutoOperacja[] ops)
        {
            foreach (AutoOperacja op in ops)
                for (int i = 0; i < ListaArgumentow.Length; i++)
                    op(ref listaArgumentow[i]);
        }

        public void Wykonaj(params Action<int[]>[] dzialania)
        {
            foreach (Action<int[]> dzialanie in dzialania)
                dzialanie(listaArgumentow);
        }

        public string ZapisTablicy()
        {
            return string.Join(", ", ListaArgumentow);
        }

        public override string ToString()
        {
            return "[" + ZapisTablicy() + "]";
        }

        public static void Kwadrat(int x) => x *= x;
        public static void Odejmij(int x) => x -= 1;

        public static void Main(string[] args)
        {
            TablicaObliczeniowa tablica = new TablicaObliczeniowa(new int[] { 1, 2, 3, 4, 5 });
            TablicaObliczeniowa tablica2 = new TablicaObliczeniowa(1, 2, 3, 4, 5);
            TablicaObliczeniowa tablica3 = new TablicaObliczeniowa(1, 2, 3, 4, 5);

            Console.WriteLine("Suma = " + tablica.Oblicz((x, y) => x + y));
            tablica.Aplikuj((ref int x) => x *= x);
            Console.WriteLine(tablica);
            tablica2.Aplikuj((ref int x) => x *= x, (ref int x) => x -= 1);
            Console.WriteLine(tablica2);
            tablica.Wykonaj(Array.Sort, Array.Reverse);
            Console.WriteLine(tablica);


            TablicaObliczeniowa.AutoOperacja operacja = null;
            operacja = (ref int x) => x *= x;
            operacja += (ref int x) => x -= 1;
            tablica3.Aplikuj(operacja);

            Console.WriteLine(tablica3);
        }
    }
}
